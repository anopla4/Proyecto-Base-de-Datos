import React, { Component } from "react";
import { Form, Button, Col, Container } from "react-bootstrap";
class Login extends Component {
  state = {
    username: undefined,
    password: undefined,
  };

  onFormSubmit = (e) => {
    let user = {
      username: this.state.username,
      password: this.state.password,
    };
    fetch("https://localhost:44334/api/Authenticate/login", {
      mode: "cors",
      headers: { "Content-Type": "application/json" },
      method: "POST",
      body: JSON.stringify(user),
    })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
          return response.json();
      })
      .then((response) => {
        this.props.onLoginCallback(user.username, user.password, response.token);
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  render() {
    return (
      <Container alignSelf="center" className="mt-5">
        <Col className="center">
          <Form>
            <Form.Group controlId="username">
              <Form.Label>Nombre de Usuario</Form.Label>
              <Form.Control
                type="username"
                placeholder="Ponga el correo"
                onChange={(e) => {this.setState({username:e.target.value})}}
              />
            </Form.Group>

            <Form.Group controlId="password">
              <Form.Label>Contraseña</Form.Label>
              <Form.Control
                type="password"
                placeholder="Contraseña"
                onChange={(e) => {this.setState({password:e.target.value})}}
              />
            </Form.Group>
            <Form.Group controlId="formBasicCheckbox">
          <Form.Check type="checkbox" label="Check me out" />
        </Form.Group>
            <Button 
              variant="primary"
              style={{ float: "right" }}
              onClick={this.onFormSubmit}
            >
              Aceptar
            </Button>
          </Form>
        </Col>
      </Container>
    );
  }
}

export default Login;
