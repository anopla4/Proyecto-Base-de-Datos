import React, { Component } from "react";
import { Card, CardDeck, Col, Row, Image, Container } from "react-bootstrap";
import "./Games.css";
import "../../containers/App/App.css";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";
import Add from "../../components/Add/Add";

class Games extends Component {
  state = {
    games: [],
  };

  handleOnClick = (game, serie) => {
    this.props.history.push({
      pathname: "/game",
      state: { game: game, serie: serie },
    });
  };

  handleOnClickAdd = (game) => {
    this.props.history.push({ pathname: "/gameForm", state: { game } });
  };

  componentDidMount() {
    fetch("https://localhost:44334/api/Game", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ games: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  handleOnDelete = (idG, index) => {
    fetch(`https://localhost:44334/api/Serie/${idG}`, {
      mode: "cors",
      method: "DELETE",
      headers:{"Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token}
    })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });

    let n_games = [...this.state.games];
    n_games.splice(index, 1);

    this.setState({ games: n_games });
  };

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">Juegos</h1>

        <CardDeck>
          {this.state.games.map((game, index) => (
            <Col md={4}>
              <Card className="mb-3 active_hover" key={game.id}>
                <Card.Header>
                  <Row className="mb-3">
                    <Col md={4}>
                      <DeleteEdit
                        delete={true}
                        edit={true}
                        onDelete={() => this.handleOnDelete(game.gameId, index)}
                        onEdit={() => this.handleOnClickAdd(game)}
                      />
                    </Col>
                    <Col className="my-series-name">{game.serie.name}</Col>
                  </Row>
                  <Row>
                    <Col>
                      {new Date(game.gameDate).toLocaleString().split(",")[0]} (
                      {game.gameTime})
                    </Col>
                  </Row>
                  <Row>
                    <Col>
                      <Image
                        rounded
                        fluid
                        src={`https://localhost:44334/${game.winnerTeam.imgPath}`}
                      />
                    </Col>
                    <Col className="my-score" style={{ textAlign: "center" }}>
                      {game.runs_in_favor} - {game.runs_against}
                    </Col>
                    <Col>
                      <Image
                        rounded
                        fluid
                        src={`https://localhost:44334/${game.loserTeam.imgPath}`}
                      />
                    </Col>
                  </Row>
                </Card.Header>
                <Card.Body>
                  <Container>
                    <p style={{ display: "inline" }}>
                      <h className="my-header-list-group-item">Fecha: </h>{" "}
                      {game.date} ({game.time}).
                    </p>
                  </Container>
                  <Container>
                    <p style={{ display: "inline" }}>
                      <Container className="bold">Lanzador ganador: </Container>{" "}
                      {game.pitcherWinner.name}.
                    </p>
                  </Container>
                  <Container>
                    <p style={{ display: "inline" }}>
                      <Container className="bold">
                        Lanzador perdedor:{" "}
                      </Container>{" "}
                      {game.pitcherLoser.name}.
                    </p>
                  </Container>
                  <Container className="my-link">
                    <Card.Link
                      href="/game"
                      onClick={() => this.handleOnClick(game, game.serie)}
                    >
                      Saber más
                    </Card.Link>
                  </Container>
                </Card.Body>
              </Card>
            </Col>
          ))}
        </CardDeck>
        <Add text="Agregar juego" onClick={() => this.handleOnClickAdd()} />
      </Container>
    );
  }
}

export default Games;
