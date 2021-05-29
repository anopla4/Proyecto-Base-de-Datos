import React, { Component } from "react";
import { Form, Button } from "react-bootstrap";
class Login extends Component {
  state = {};
  render() {
    return (
      <Form>
        <Form.Group controlId="email">
          <Form.Label>Email address</Form.Label>
          <Form.Control type="email" placeholder="Ponga el correo" />
        </Form.Group>

        <Form.Group controlId="password">
          <Form.Label>Password</Form.Label>
          <Form.Control type="password" placeholder="Contraseña" />
        </Form.Group>
        {/* <Form.Group controlId="formBasicCheckbox">
          <Form.Check type="checkbox" label="Check me out" />
        </Form.Group> */}
        <Button variant="primary" type="submit">
          Aceptar
        </Button>
      </Form>
    );
  }
}

export default Login;
