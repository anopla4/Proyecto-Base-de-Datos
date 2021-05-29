import React, { Component } from "react";
import { Form, Button, Row, Col, Container, Image } from "react-bootstrap";
import "./PlayerForm.css";

class PlayerForm extends Component {
  state = {
    changed: false,
    selectedPositions: [],
    hands: ["Izquierda", "Derecha"],
    positions: [
      { id: 1, positionName: "Primera base" },
      { id: 2, positionName: "Lanzador" },
      { id: 3, positionName: "Segunda base" },
    ],
    players: [
      { name: "Alexander Malleta" },
      { name: "Frank Camilo" },
      { name: "Pedro Luis Lazo" },
      { name: "César Prieto" },
    ],
    teams: [
      { name: "Industriales" },
      { name: "Matanzas" },
      { name: "Cienfuegos" },
      { name: "Pinar del Río" },
    ],
  };
  onChange = (e) => {
    e.preventDefault();
    this.setState((prevState) => ({
      changed: true,
      selectedPositions: [...prevState.selectedPositions, e.target.value],
    }));
  };

  render() {
    const {
      id,
      name,
      img,
      age,
      year_Experience,
      current_Team,
      era,
      hand,
      position,
      position_Average,
    } = {
      ...this.props.location.state.player,
    };
    return (
      <Container alignSelf="center" className="mt-4">
        <Col className="center">
          <Form style={{ width: "70%", alignItems: "center" }}>
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="name">
                  <Form.Label>Nombre:</Form.Label>
                  <Form.Control type="text" value={name ? name : ""} />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group>
                  <Image src={img} />
                  <Form.File id="img" label="Imagen del jugador" />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="currentTeam">
                  <Form.Label>Equipo actual:</Form.Label>
                  <Form.Control
                    value={current_Team ? current_Team : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    <option>{"Retirado"}</option>
                    {this.state.teams.map((team) => (
                      <option>{team.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="age">
                  <Form.Label>Edad:</Form.Label>
                  <Form.Control
                    value={age ? age : ""}
                    type="numeric"
                    name="age"
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="hand">
                  <Form.Label>Años de experiencia:</Form.Label>
                  <Form.Control
                    value={year_Experience ? year_Experience : ""}
                    type="numeric"
                    name="year_Experience"
                  />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group controlId="position">
                  <Form.Label>Posición:</Form.Label>
                  <Form.Control
                    value={
                      position && !this.state.changed
                        ? position.map((pos) => pos.positionName)
                        : undefined
                    }
                    as="select"
                    onChange={this.onChange}
                    custom
                    multiple
                  >
                    <option>{""}</option>
                    {this.state.positions.map((pos) => (
                      <option>{pos.positionName}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="hand">
                  <Form.Label>Mano:</Form.Label>
                  <Form.Control value={hand ? hand : ""} as="select" custom>
                    <option>{""}</option>
                    {this.state.hands.map((hand) => (
                      <option>{hand}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
            </Row>

            <Row>
              <Col>
                <Form.Group controlId="era">
                  <Form.Label>Promedio de carreras limpias:</Form.Label>
                  <Form.Control
                    value={era ? era : ""}
                    type="numeric"
                    name="era"
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="position_Average">
                  <Form.Label>Average:</Form.Label>
                  <Form.Control
                    value={position_Average ? position_Average : ""}
                    type="numeric"
                    name="position_Average"
                  />
                </Form.Group>
              </Col>
            </Row>
            <Button
              style={{ float: "right" }}
              className="mt-3 ml-3"
              variant="secondary"
              type="reset"
            >
              Reiniciar
            </Button>
            <Button
              style={{ float: "right" }}
              className="mt-3 ml-3"
              variant="primary"
              type="submit"
            >
              Aceptar
            </Button>
          </Form>
        </Col>
      </Container>
    );
  }
}

export default PlayerForm;
