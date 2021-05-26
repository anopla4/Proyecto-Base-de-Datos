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
// import DatePicker from "react-bootstrap-date-picker/src/index.jsx";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

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
      <Form style={{ width: "70%" }} className="center">
        <Container>
          <Row>
            <Col>
              <Form.Group controlId="name">
                <Form.Label>Nombre</Form.Label>
                <Form.Control type="text" placeholder="" />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group controlId="number-of-games">
                <Form.Label>Número de juegos</Form.Label>
                <Form.Control type="text" placeholder="" />
                {/* <NumericInput /> */}
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Group controlId="date">
                <Form.Label>Fecha de incio</Form.Label>
                <Container>
                  <DatePicker id="datepicker-begin" />
                </Container>
              </Form.Group>
            </Col>
            <Col>
              <Form.Group controlId="date">
                <Form.Label>Fecha de culminación</Form.Label>
                <Container>
                  <DatePicker id="datepicker-end" />
                </Container>
              </Form.Group>
            </Col>
          </Row>

          <Row>
            <Form.Group controlId="reach">
              <Form.Label>Carácter</Form.Label>
              <Form.Control as="select" custom>
                <option>Elija un carácter...</option>
                {this.state.reaches.map((reach) => (
                  <option>{reach}</option>
                ))}
              </Form.Control>
            </Form.Group>
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
            className="mt-3"
            variant="primary"
            type="submit"
          >
            Aceptar
          </Button>
        </Container>
      </Form>
    );
  }
}

export default SerieForm;
