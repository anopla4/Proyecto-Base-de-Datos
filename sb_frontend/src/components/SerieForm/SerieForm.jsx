import React, { Component } from "react";
import {
  Form,
  Button,
  NumericInput,
  Row,
  Col,
  Container,
} from "react-bootstrap";
import "./SerieForm.css";
import InputNumber from "rc-input-number";

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
    return (
      <Container alignSelf="center" className="mt-4">
        <Col className="center">
          <Form style={{ width: "70%", alignItems: "center" }}>
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="name">
                  <Form.Label>Nombre:</Form.Label>
                  <Form.Control type="text" placeholder="" />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group controlId="date-begin" bsSize="large">
                  <Form.Label>Fecha de incio:</Form.Label>
                  <Form.Control type="date" />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="date-end" bsSize="large">
                  <Form.Label>Fecha de culminación:</Form.Label>
                  <Form.Control type="date" />
                </Form.Group>
              </Col>
            </Row>

            <Row>
              <Col>
                <Form.Group controlId="reach">
                  <Form.Label>Carácter:</Form.Label>
                  <Form.Control as="select" custom>
                    <option>Elija un carácter...</option>
                    {this.state.reaches.map((reach) => (
                      <option>{reach}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="number-of-games">
                  <Form.Label>Número de juegos:</Form.Label>
                  <Form.Control type="numeric" name="number-of-games" />
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
              Reset
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