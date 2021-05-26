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
  render() {
    console.log(this.props);
    return (
      <Accordion>
        {this.props.players.map((player) => (
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
                    {player.positions.join(", ")}.
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
                <Row className="bold">
                  <Col md={1}>Edad</Col>
                  <Col>Equipo actual</Col>
                  <Col>Equipos</Col>
                  <Col>Años de experiencia</Col>
                  {player.positions.includes("Lanzador") && <Col>Mano</Col>}
                  {player.positions.includes("Lanzador") && (
                    <Col md={1}>ERA</Col>
                  )}
                  {player.positions.length === 1 &&
                    !player.positions.includes("Lanzador") && (
                      <Col md={1}>AVE</Col>
                    )}
                </Row>
                <Row>
                  <Col md={1}>{player.age}</Col>
                  <Col>{player.current_team}</Col>
                  <Col>{player.teams.join(", ")}.</Col>
                  <Col>{player.years_of_experience}</Col>
                  {player.positions.includes("Lanzador") && (
                    <Col>{player.hand}</Col>
                  )}
                  {player.positions.includes("Lanzador") && (
                    <Col md={1}>{player.era}</Col>
                  )}
                  {player.positions.length === 1 &&
                    !player.positions.includes("Lanzador") && (
                      <Col md={1}>{player.ave}</Col>
                    )}
                </Row>
              </Card.Body>
            </Accordion.Collapse>
          </Card>
        ))}
      </Accordion>
    );
  }
}

export default Players;