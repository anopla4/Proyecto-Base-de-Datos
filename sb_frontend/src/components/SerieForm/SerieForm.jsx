import React, { Component } from "react";
import { Form, Button, Row, Col, Container } from "react-bootstrap";
import "./SerieForm.css";

class SerieForm extends Component {
  state = {
    reaches: ["Nacional", "Provincial"],
    teams: [
      { name: "Industriales" },
      { name: "Matanzas" },
      { name: "Cienfuegos" },
      { name: "Ciego de Ávila" },
    ],
  };
  render() {
    let newDate = new Date();
    let date = newDate.getDate();
    // let years = Array.from(Array(year).keys()).reverse();
    const { id, name, caracter, initDate, endDate, numberOfGames } = {
      ...this.props.location.state.serie,
    };
    return (
      <Container alignSelf="center" className="mt-4">
        <h1 className="mb-5 my-style-header">Serie</h1>

        <Col className="center">
          <Form style={{ width: "70%", alignItems: "center" }}>
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="name">
                  <Form.Label>Nombre:</Form.Label>
                  <Form.Control
                    defaultValue={name}
                    type="text"
                    // value={"" || name}
                  />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                {/* <Form.Group controlId="date-begin">
                  <Form.Label>Fecha de incio:</Form.Label>
                  <Form.Control
                    value={seasonStart ? seasonStart : { year }}
                    as="select"
                    custom
                  >
                    {years.map((year) => (
                      <option>{year}</option>
                    ))}
                  </Form.Control>
                </Form.Group> */}
                <Form.Group controlId="date-begin" bsSize="large">
                  <Form.Label>Fecha de incio:</Form.Label>
                  <Form.Control
                    value={
                      initDate
                        ? new Date(initDate).toISOString().substr(0, 10)
                        : ""
                    }
                    type="date"
                  />
                </Form.Group>
              </Col>
              <Col>
                {/* <Form.Group controlId="date-end">
                  <Form.Label>Fecha de culminación:</Form.Label>
                  <Form.Control
                    value={seasonEnd ? seasonEnd : { year }}
                    as="select"
                    custom
                  >
                    {years.map((year) => (
                      <option>{year}</option>
                    ))}
                  </Form.Control>
                </Form.Group> */}
                <Form.Group controlId="date-end" bsSize="large">
                  <Form.Label>Fecha de culminación:</Form.Label>
                  <Form.Control
                    value={
                      endDate
                        ? new Date(endDate).toISOString().substr(0, 10)
                        : ""
                    }
                    type="date"
                  />
                </Form.Group>
              </Col>
            </Row>

            <Row>
              <Col>
                <Form.Group controlId="reach">
                  <Form.Label>Carácter:</Form.Label>
                  <Form.Control
                    value={caracter ? caracter.caracter_Name : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.reaches.map((reach) => (
                      <option>{reach}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="number-of-games">
                  <Form.Label>Número de juegos:</Form.Label>
                  <Form.Control
                    value={numberOfGames ? numberOfGames : ""}
                    type="numeric"
                    name="number-of-games"
                  />
                </Form.Group>
              </Col>
            </Row>

            {/* <Form.Group controlId="winner-team">
          <Form.Label>Primer lugar</Form.Label>
          <Form.Control as="select" custom>
            <option>Elija un equipo...</option>
            {this.state.teams
              .map((team) => team.name)
              .map((team) => (
                <option>{team}</option>
              ))}
          </Form.Control>
        </Form.Group>

        <Form.Group controlId="loser-team">
          <Form.Label>Último lugar</Form.Label>
          <Form.Control as="select" custom>
            <option>Elija un equipo...</option>
            {this.state.teams
              .map((team) => team.name)
              .map((team) => (
                <option>{team}</option>
              ))}
          </Form.Control>
        </Form.Group> */}
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

export default SerieForm;
