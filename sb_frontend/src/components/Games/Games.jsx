import React, { Component } from "react";
import {
  Card,
  CardDeck,
  Col,
  Row,
  Image,
  ListGroup,
  ListGroupItem,
  Container,
} from "react-bootstrap";
import "./Games.css";
import "../../containers/App/App.css";

class Games extends Component {
  state = {
    games: [
      {
        id: 1,
        winner: {
          id: 2,
          name: "Industriales",
          color: "Azul",
          iniciales: "IND",
          img: "http://localhost:8000/src/logos/industriales.png",
        },
        loser: {
          id: 1,
          name: "Pinar del Río",
          color: "Verde, Blanco",
          iniciales: "PR",
          img: "http://localhost:8000/src/logos/pinar-del-rio.jpg",
        },
        serie: {
          id: 1,
          name: "Serie Nacional de Béisbol",
        },
        runs_in_favor: 4,
        runs_against: 3,
        date: "5 de febrero de 2009",
        time: "2 pm",
        winner_pitcher: { name: "Rivero" },
      },
      {
        id: 2,
        winner: {
          id: 2,
          name: "Matanzas",
          color: "MTN",
          iniciales: "IND",
          img: "http://localhost:8000/src/logos/matanzas.png",
        },
        loser: {
          id: 1,
          name: "Cienfuegos",
          color: "Verde, Blanco",
          iniciales: "CNF",
          img: "http://localhost:8000/src/logos/cienfuegos.png",
        },
        serie: {
          id: 1,
          name: "Serie Nacional de Béisbol",
        },
        runs_in_favor: 5,
        runs_against: 1,
        date: "5 de febrero de 2009",
        time: "2 pm",
        winner_pitcher: { name: "Rivero" },
      },
      {
        id: 3,
        winner: {
          id: 9,
          name: "Sancti Spíritus",
          color: "Azul, Rojo",
          iniciales: "SNC",
          img: "http://localhost:8000/src/logos/sancti_spiritus.png",
        },
        loser: {
          id: 2,
          name: "Camagüey",
          color: "Verde, Blanco",
          iniciales: "CMY",
          img: "http://localhost:8000/src/logos/camagüey.png",
        },
        serie: {
          id: 1,
          name: "Serie Nacional de Béisbol",
        },
        runs_in_favor: 4,
        runs_against: 3,
        date: "5 de febrero de 2009",
        time: "2 pm",
        winner_pitcher: { name: "Rivero" },
      },
    ],
  };

  handleOnClick = (idG) => {
    this.props.history.push({ pathname: "/game", state: { idGame: idG } });
  };

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">Juegos</h1>

        <CardDeck>
          {this.state.games.map((game) => (
            <Col md={4}>
              <Card className="mb-3 active_hover" key={game.id}>
                <Card.Header>
                  <Row className="mb-2">
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
                      onClick={() => this.handleOnClick(game.id)}
                    >
                      Saber más
                    </Card.Link>
                  </Container>
                </Card.Body>
              </Card>
            </Col>
          ))}
        </CardDeck>
      </Container>
    );
  }
}

export default Games;
