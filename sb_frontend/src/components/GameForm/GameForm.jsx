import React, { Component } from "react";
import { Form, Button, Row, Col, Container } from "react-bootstrap";
import "./GameForm.css";

class GameForm extends Component {
  state = {
    changed: false,
    pitchers: [{ name: "Rivero" }, { name: "Pedro Luis Lazo" }],
    teams: [
      { name: "Industriales" },
      { name: "Matanzas" },
      { name: "Cienfuegos" },
      { name: "Pinar del Río" },
    ],
    series: [
      {
        id: 1,
        name: "Serie Nacional de Béisbol",
        caracter: "Nacional",
        initDate: "1994",
        endDate: "1995",
        numberOfGames: "50",
        nt: "15",
        winner: "Industriales",
        loser: "Isla de la Juventud",
      },
      {
        id: 2,
        name: "Serie Nacional de Béisbol",
        caracter: "Nacional",
        initDate: "1996",
        endDate: "1997",
        numberOfGames: "40",
        nt: "15",
        winner: "Matanzas",
        loser: "Las Tunas",
      },
    ],
  };
  //   onChange = (e) => {
  //     e.preventDefault();
  //     this.setState((prevState) => ({
  //       changed: true,
  //       selectedPositions: [...prevState.selectedPositions, e.target.value],
  //     }));
  //   };

  render() {
    const {
      id,
      winner,
      loser,
      serie,
      winner_pitcher,
      runs_in_favor,
      runs_against,
    } = {
      ...this.props.location.state.game,
    };
    return (
      <Container alignSelf="center" className="mt-4">
        <Col className="center">
          <Form style={{ width: "70%", alignItems: "center" }}>
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="serie">
                  <Form.Label>Serie:</Form.Label>
                  <Form.Control
                    value={
                      serie
                        ? serie.name +
                          " (" +
                          serie.initDate +
                          " - " +
                          serie.endDate +
                          ")"
                        : ""
                    }
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.series.map((serie) => (
                      <option>
                        {serie.name} ({serie.initDate} - {serie.endDate})
                      </option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group
                  style={{ width: "100%" }}
                  controlId="winner_pitcher"
                >
                  <Form.Label>Lanzador ganador:</Form.Label>
                  <Form.Control
                    value={winner_pitcher ? winner_pitcher.name : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.pitchers.map((pitcher) => (
                      <option>{pitcher.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group controlId="runs_in_favor">
                  <Form.Label>Carreras a favor:</Form.Label>
                  <Form.Control
                    value={runs_in_favor ? runs_in_favor : ""}
                    type="numeric"
                    name="runs_in_favor"
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="runs_against">
                  <Form.Label>Carreras en contra:</Form.Label>
                  <Form.Control
                    value={runs_against ? runs_against : ""}
                    type="numeric"
                    name="runs_against"
                  />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="winner">
                  <Form.Label>Ganador:</Form.Label>
                  <Form.Control
                    value={winner ? winner.name : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.teams.map((team) => (
                      <option>{team.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="loser">
                  <Form.Label>Perdedor:</Form.Label>
                  <Form.Control
                    value={loser ? loser.name : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.teams.map((team) => (
                      <option>{team.name}</option>
                    ))}
                  </Form.Control>
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

export default GameForm;
