import React, { Component } from "react";
import {
  Container,
  Accordion,
  Card,
  Col,
  Row,
  Image,
  Button,
  Table,
} from "react-bootstrap";
import chevron from "../../static/chevron-compact-down.svg";
import "./Players.css";
import "../../containers/App/App.css";

class Players extends Component {
  state = {
    players: [
      {
        id: 1,
        name: "Alexander Malleta",
        positions: ["Primera base"],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_team: "Retirado",
        years_of_experience: 20,
        ave: 301,
      },
      {
        id: 2,
        name: "Pedro Luis Lazo",
        positions: ["Lanzador"],
        img: "http://localhost:8000/src/logos/pedro_luis_lazo.jpg",
        age: 49,
        teams: ["Pinar del Río"],
        current_team: "Retirado",
        years_of_experience: 20,
        era: 3.22,
        hand: "Derecha",
      },
    ],
  };

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">Jugadores de pelota</h1>
        <Accordion>
          {this.state.players.map((player) => (
            <Card key={player.id}>
              <Card.Header style={{ padding: "0.5%" }}>
                <Row className="row">
                  <Col md={1}>
                    <Image
                      fluid
                      roundedCircle
                      src={player.img}
                      alt=""
                      className="custom-circle-image"
                    />
                  </Col>
                  <Col>
                    <h6>{player.name}</h6>
                    <p style={{ display: "inline" }}>
                      <h className="header-posiciones">Posiciones: </h>
                      {player.positions.map((team) => (
                        <li
                          className="list-posiciones"
                          style={{ display: "inline" }}
                        >
                          {team}{" "}
                        </li>
                      ))}
                    </p>
                  </Col>
                  <Col md={1}>
                    <Accordion.Toggle
                      as={Button}
                      variant="link"
                      eventKey={player.id}
                      className="my-button"
                    >
                      <Image src={chevron} />
                    </Accordion.Toggle>
                  </Col>
                </Row>
              </Card.Header>
              <Accordion.Collapse eventKey={player.id}>
                <Card.Body>
                  <Table>
                    <tr>
                      <th>Edad</th>
                      <th>Equipo actual</th>
                      <th>Equipos</th>
                      <th>Años de experiencia</th>
                      {player.positions.includes("Lanzador") && <th>Mano</th>}
                      {player.positions.includes("Lanzador") && <th>ERA</th>}
                      {player.positions.length === 1 &&
                        !player.positions.includes("Lanzador") && <th>AVE</th>}
                    </tr>
                    <tr>
                      <td>{player.age}</td>
                      <td>{player.current_team}</td>
                      <td>
                        {player.teams.map((team) => (
                          <li>{team} </li>
                        ))}
                      </td>
                      <td>{player.years_of_experience}</td>
                      {player.positions.includes("Lanzador") && (
                        <td>{player.era}</td>
                      )}
                      {player.positions.includes("Lanzador") && (
                        <td>{player.hand}</td>
                      )}
                      {player.positions.length === 1 &&
                        !player.positions.includes("Lanzador") && (
                          <td>{player.ave}</td>
                        )}
                    </tr>
                  </Table>
                </Card.Body>
              </Accordion.Collapse>
            </Card>
          ))}
        </Accordion>
      </Container>
    );
  }
}

export default Players;
