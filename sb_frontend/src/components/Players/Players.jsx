import React, { Component } from "react";
import { Accordion, Card, Col, Row, Image, Button } from "react-bootstrap";
import chevron from "../../static/chevron-compact-down.svg";
import "./Players.css";
import "../../containers/App/App.css";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";

class Players extends Component {
  render() {
    console.log("Ana");
    return (
      <Accordion className="mb-3">
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
                  <h6
                    className="header"
                    onClick={() => this.props.onClick(player.id)}
                  >
                    {player.name}
                  </h6>
                  <p style={{ display: "inline" }}>
                    <h className="header-posiciones">Posiciones: </h>
                    {player.position.map((pos) => pos.positionName).join(", ")}.
                  </p>
                </Col>

                <Col md={2}>
                  <Accordion.Toggle
                    as={Button}
                    variant="link"
                    eventKey={player.id}
                    className="my-button"
                  >
                    <Image src={chevron} />
                  </Accordion.Toggle>
                </Col>
                <Col md={2}>
                  <DeleteEdit
                    delete={this.props.delete}
                    edit={this.props.edit}
                    onEdit={() => this.props.onEdit(player)}
                    onDelete={this.props.onDelete}
                    space="2"
                    size="sm"
                    top="3"
                  />
                </Col>
              </Row>
            </Card.Header>
            <Accordion.Collapse eventKey={player.id}>
              <Card.Body>
                <Row className="bold set-size">
                  <Col md={2}>Edad</Col>
                  {this.props.playerGeneral && <Col>Equipo actual</Col>}
                  {this.props.playerGeneral && <Col>Equipos</Col>}
                  <Col>Años de experiencia</Col>
                  {player.position
                    .map((pos) => pos.positionName)
                    .includes("Lanzador") && <Col>Mano</Col>}
                  {player.position
                    .map((pos) => pos.positionName)
                    .includes("Lanzador") && <Col md={2}>ERA</Col>}
                  {player.position.length === 1 &&
                    !player.position
                      .map((pos) => pos.positionName)
                      .includes("Lanzador") && <Col md={2}>AVE</Col>}
                </Row>
                <Row className="set-size">
                  <Col md={2}>{player.age}</Col>
                  {this.props.playerGeneral && <Col>{player.current_Team}</Col>}
                  {this.props.playerGeneral && (
                    <Col>{player.teams.join(", ")}.</Col>
                  )}
                  <Col>{player.year_Experience}</Col>
                  {player.position
                    .map((pos) => pos.positionName)
                    .includes("Lanzador") && <Col>{player.hand}</Col>}
                  {player.position
                    .map((pos) => pos.positionName)
                    .includes("Lanzador") && <Col md={2}>{player.era}</Col>}
                  {player.position.length === 1 &&
                    !player.position
                      .map((pos) => pos.positionName)
                      .includes("Lanzador") && (
                      <Col md={2}>{player.position_Average}</Col>
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
