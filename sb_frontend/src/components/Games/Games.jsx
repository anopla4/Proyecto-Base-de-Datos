import React, { Component } from "react";
import { Card, CardDeck, Col, Row, Image, Container } from "react-bootstrap";
import "./Games.css";
import "../../containers/App/App.css";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";
import Add from "../../components/Add/Add";

class Games extends Component {
  state = {
    games: [],
    // games: [
    //   {
    //     id: 1,
    //     winner: {
    //       id: 2,
    //       name: "Industriales",
    //       color: "Azul",
    //       iniciales: "IND",
    //       img: "http://localhost:8000/src/logos/industriales.png",
    //     },
    //     loser: {
    //       id: 1,
    //       name: "Pinar del Río",
    //       color: "Verde, Blanco",
    //       iniciales: "PR",
    //       img: "http://localhost:8000/src/logos/pinar-del-rio.jpg",
    //     },
    //     serie: {
    //       id: 1,
    //       name: "Serie Nacional de Béisbol",
    //     },
    //     runs_in_favor: 4,
    //     runs_against: 3,
    //     date: "5 de febrero de 2009",
    //     time: "2 pm",
    //     winner_pitcher: { name: "Rivero" },
    //   },
    //   {
    //     id: 2,
    //     winner: {
    //       id: 2,
    //       name: "Matanzas",
    //       color: "MTN",
    //       iniciales: "IND",
    //       img: "http://localhost:8000/src/logos/matanzas.png",
    //     },
    //     loser: {
    //       id: 1,
    //       name: "Cienfuegos",
    //       color: "Verde, Blanco",
    //       iniciales: "CNF",
    //       img: "http://localhost:8000/src/logos/cienfuegos.png",
    //     },
    //     serie: {
    //       id: 1,
    //       name: "Serie Nacional de Béisbol",
    //     },
    //     runs_in_favor: 5,
    //     runs_against: 1,
    //     date: "5 de febrero de 2009",
    //     time: "2 pm",
    //     winner_pitcher: { name: "Rivero" },
    //   },
    //   {
    //     id: 3,
    //     winner: {
    //       id: 9,
    //       name: "Sancti Spíritus",
    //       color: "Azul, Rojo",
    //       iniciales: "SNC",
    //       img: "http://localhost:8000/src/logos/sancti_spiritus.png",
    //     },
    //     loser: {
    //       id: 2,
    //       name: "Camagüey",
    //       color: "Verde, Blanco",
    //       iniciales: "CMY",
    //       img: "http://localhost:8000/src/logos/camagüey.png",
    //     },
    //     serie: {
    //       id: 1,
    //       name: "Serie Nacional de Béisbol",
    //     },
    //     runs_in_favor: 4,
    //     runs_against: 3,
    //     date: "5 de febrero de 2009",
    //     time: "2 pm",
    //     winner_pitcher: { name: "Rivero" },
    //   },
    // ],
  };

  handleOnClick = (idG, idS) => {
    this.props.history.push({
      pathname: "/game",
      state: { idGame: idG, idSerie: idS },
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

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">Juegos</h1>

        <CardDeck>
          {this.state.games.map((game) => (
            <Col md={4}>
              <Card className="mb-3 active_hover" key={game.id}>
                <Card.Header>
                  <Row className="mb-3">
                    <Col md={4}>
                      <DeleteEdit
                        delete={true}
                        edit={true}
                        onEdit={() => this.handleOnClickAdd(game)}
                      />
                    </Col>
                    <Col className="my-series-name">{game.serie.name}</Col>
                  </Row>
                  <Row>
                    <Col>
                      <Image rounded fluid src={game.winner.img} />
                    </Col>
                    <Col className="my-score" style={{ textAlign: "center" }}>
                      {game.runs_in_favor} - {game.runs_against}
                    </Col>
                    <Col>
                      <Image rounded fluid src={game.loser.img} />
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
                      <h className="bold">Lanzador ganador: </h>{" "}
                      {game.winner_pitcher.name}.
                    </p>
                  </Container>
                  <Container className="my-link">
                    <Card.Link
                      href="/game"
                      onClick={() => this.handleOnClick(game.id, game.serie.id)}
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
