import React, { Component } from "react";
import { Form, Button, Col, Container } from "react-bootstrap";
class Login extends Component {
  state = {};
  render() {
    return (
      <Container alignSelf="center" className="mt-5">
        <Col className="center">
          <Form style={{ width: "50%" }}>
            <Form.Group controlId="email">
              <Form.Label>Correo electrónico</Form.Label>
              <Form.Control type="email" placeholder="Ponga el correo" />
            </Form.Group>

            <Form.Group controlId="password">
              <Form.Label>Contraseña</Form.Label>
              <Form.Control type="password" placeholder="Contraseña" />
            </Form.Group>
            {/* <Form.Group controlId="formBasicCheckbox">
          <Form.Check type="checkbox" label="Check me out" />
        </Form.Group> */}
            <Button variant="primary" type="submit" style={{ float: "right" }}>
              Aceptar
            </Button>
          </Form>
        </Col>
      </Container>
    );
  }
}

export default Login;
