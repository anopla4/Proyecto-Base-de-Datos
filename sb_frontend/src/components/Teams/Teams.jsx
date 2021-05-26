import React, { Component } from "react";
import {
  Container,
  Card,
  ListGroup,
  ListGroupItem,
  CardDeck,
  Col,
} from "react-bootstrap";
import "../../containers/App/App.css";

class Teams extends Component {
  state = {
    teams: [
      {
        id: 1,
        name: "Matanzas",
        color: "Rojo, Amarillo",
        iniciales: "MTN",
        img: "http://localhost:8000/src/logos/matanzas.png",
      },
      {
        id: 2,
        name: "Pinar del Río",
        color: "Verde, Blanco",
        iniciales: "PR",
        img: "http://localhost:8000/src/logos/pinar-del-rio.jpg",
      },
      {
        id: 3,
        name: "Industriales",
        color: "Azul",
        iniciales: "IND",
        img: "http://localhost:8000/src/logos/industriales.png",
      },
      {
        id: 4,
        name: "Cienfuegos",
        color: "Verde, Blanco",
        iniciales: "CFG",
        img: "http://localhost:8000/src/logos/cienfuegos.png",
      },
    ],
  };

  handleOnClick = (idT) => {
    this.props.history.push({ pathname: "/team", state: { idTeam: idT } });
  };

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">Equipos de béisbol</h1>
        <CardDeck>
          {this.state.teams.map((team) => (
            <Col md="4">
              <Card
                className="mb-3"
                key={team.id}
                style={{ width: "18rem" }}
                border="primary"
              >
                <Card.Img height="250vw" variant="top" src={team.img} />
                <Card.Body>
                  <Card.Title>{team.iniciales}</Card.Title>
                  <Card.Subtitle>{team.name}</Card.Subtitle>
                </Card.Body>
                <ListGroup className="list-group-flush">
                  <ListGroupItem>Color: {team.color}</ListGroupItem>
                </ListGroup>
                <Card.Body>
                  <Card.Link
                    href="/team"
                    onClick={() => this.handleOnClick(team.id)}
                  >
                    Saber más
                  </Card.Link>
                </Card.Body>
              </Card>
            </Col>
          ))}
        </CardDeck>
      </Container>
    );
  }
}

export default Teams;
