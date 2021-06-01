import React, { Component } from "react";
import { Accordion, Card, Col, Row, Image, Button } from "react-bootstrap";
import chevron from "../../static/chevron-compact-down.svg";
import "./Players.css";
import "../../containers/App/App.css";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";

class Players extends Component {
  render() {
    return (
      <Accordion className="mb-3">
        {this.props.players.map((player, index) => (
          <Card key={player.id}>
            <Card.Header style={{ padding: "0.5%" }}>
              <Row className="row">
                <Col md={1}>
                  <Image
                    fluid
                    roundedCircle
                    src={`https://localhost:44334/${player.imgPath}`}
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
                    onEdit={() => this.props.onEdit(player.id)}
                    onDelete={() => this.props.onDelete(player.id, index)}
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
                  <Col>Average defensivo</Col>
                  {player.positions
                    .map((pos) => pos.positionName)
                    .includes("P") && <Col>Mano</Col>}
                  {player.positions
                    .map((pos) => pos.positionName)
                    .includes("P") && <Col md={2}>ERA</Col>}
                  {player.positions.length === 1 &&
                    !player.positions
                      .map((pos) => pos.positionName)
                      .includes("P") && <Col md={2}>AVE</Col>}
                </Row>
                <Row className="set-size">
                  <Col md={2}>{player.age}</Col>
                  {this.props.playerGeneral && <Col>{player.current_Team}</Col>}
                  {this.props.playerGeneral && (
                    <Col>{player.teams.join(", ")}.</Col>
                  )}
                  <Col>{player.year_Experience}</Col>
                  {player.positions
                    .map((pos) => pos.positionName)
                    .includes("P") && <Col>{player.hand}</Col>}
                  <Col>{player.deffAverage}</Col>
                  {player.positions
                    .map((pos) => pos.positionName)
                    .includes("P") && <Col md={2}>{player.era}</Col>}
                  {player.positions.length === 1 &&
                    !player.positions
                      .map((pos) => pos.positionName)
                      .includes("P") && <Col md={2}>{player.average}</Col>}
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
