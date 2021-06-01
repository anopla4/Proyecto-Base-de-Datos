import React, { Component } from "react";
import {
  Form,
  Button,
  Row,
  Col,
  Container,
  Navbar,
  Nav,
} from "react-bootstrap";
import "./SerieForm.css";

class SerieForm extends Component {
  state = {
    edit: false,
    reaches: [],
    addCaracter: false,
  };

  componentWillMount() {
    fetch("https://localhost:44334/api/Caracter", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ reaches: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  componentDidMount() {
    if (this.props.location.state.serie) {
      this.setState({ edit: true });
    }
  }

  onFormSubmit = (e) => {
    let formElements = e.target.elements;
    const name = formElements.name.value;
    const initDate = this.state.edit
      ? this.props.location.state.serie.initDate
      : formElements.initDate.value;
    const endDate = this.state.edit
      ? this.props.location.state.serie.endDate
      : formElements.endDate.value;
    const caracter = formElements.caracter;
    const caracterId = caracter.children[caracter.selectedIndex].id;
    const numberOfGames = formElements.numberOfGames.value;
    const numberOfTeams = formElements.numberOfTeams.value;

    let serie = {
      name,
      initDate,
      endDate,
      caracterId,
      numberOfGames,
      numberOfTeams,
    };
    let postUrl =
      "https://localhost:44334/api/Serie" +
      (this.state.edit
        ? `/${this.props.location.state.serie.id}/${serie.initDate}/${serie.endDate}`
        : "");
    fetch(postUrl, {
      mode: "cors",
      headers: { "Content-Type": "application/json" },
      method: this.state.edit ? "PATCH" : "POST",
      body: JSON.stringify(serie),
    })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    this.props.history.push({ pathname: "/series", state: { edited: true } });
  };

  onFormSubmitCaracter = (e) => {
    let formElements = e.target.elements;
    const caracter_Name = formElements.name.value;
    let caracter = {
      caracter_Name,
    };
    fetch("https://localhost:44334/api/Caracter", {
      mode: "cors",
      headers: { "Content-Type": "application/json" },
      method: "POST",
      body: JSON.stringify(caracter),
    })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    this.setState({ addCaracter: false });
  };

  handleCloseAdd = () => {
    this.setState({ addCaracter: false });
  };

  handleAddCaracter = () => {
    this.setState({ addCaracter: true });
  };

  render() {
    const {
      id,
      name,
      caracterSerie,
      initDate,
      endDate,
      numberOfGames,
      numberOfTeams,
    } = {
      ...this.props.location.state.serie,
    };
    return (
      <Container alignSelf="center" className="mt-4">
        <h1 className="mb-5 my-style-header">Serie</h1>
        <Row>
          <Col className="center">
            <Form
              key={
                this.props.location.state.serie
                  ? this.props.location.state.serie.id
                  : 0
              }
              style={{ width: "70%", alignItems: "center" }}
              onSubmit={this.onFormSubmit}
            >
              <Row>
                <Col>
                  <Form.Group style={{ width: "100%" }} controlId="name">
                    <Form.Label>Nombre:</Form.Label>
                    <Form.Control defaultValue={name} type="text" />
                  </Form.Group>
                </Col>
              </Row>
              <Row>
                <Col>
                  <Form.Group controlId="initDate" bsSize="large">
                    <Form.Label>Fecha de incio:</Form.Label>
                    <Form.Control
                      defaultValue={
                        initDate
                          ? new Date(initDate).toISOString().substr(0, 10)
                          : ""
                      }
                      disabled={this.state.edit ? true : false}
                      type="date"
                    />
                  </Form.Group>
                </Col>
                <Col>
                  <Form.Group controlId="endDate" bsSize="large">
                    <Form.Label>Fecha de culminación:</Form.Label>
                    <Form.Control
                      defaultValue={
                        endDate
                          ? new Date(endDate).toISOString().substr(0, 10)
                          : ""
                      }
                      disabled={this.state.edit ? true : false}
                      type="date"
                    />
                  </Form.Group>
                </Col>
              </Row>

              <Row>
                <Col>
                  <Form.Group controlId="caracter">
                    <Form.Label>Carácter:</Form.Label>
                    <Form.Control
                      defaultValue={
                        caracterSerie ? caracterSerie.caracter_Name : ""
                      }
                      as="select"
                      custom
                    >
                      <option id={caracterSerie ? caracterSerie.id : ""}>
                        {caracterSerie ? caracterSerie.caracter_Name : ""}
                      </option>
                      {this.state.reaches.map((reach) => (
                        <option
                          value={reach.caracter_Name}
                          id={reach.id}
                          key={reach.id}
                          onChange={this.onChangeSelect}
                        >
                          {reach.caracter_Name}
                        </option>
                      ))}
                    </Form.Control>
                  </Form.Group>
                </Col>
                <Col>
                  <Form.Group controlId="numberOfGames">
                    <Form.Label>Número de juegos:</Form.Label>
                    <Form.Control
                      defaultValue={numberOfGames ? numberOfGames : ""}
                      type="numeric"
                      name="numberOfGames"
                    />
                  </Form.Group>
                </Col>
                <Col>
                  <Form.Group controlId="numberOfTeams">
                    <Form.Label>Número de equipos:</Form.Label>
                    <Form.Control
                      defaultValue={numberOfTeams ? numberOfTeams : ""}
                      type="numeric"
                      name="numberOfTeams"
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
                // onClick={this.handleOnClickAccept}
                className="mt-3 ml-3"
                variant="primary"
                type="submit"
              >
                Aceptar
              </Button>
            </Form>
          </Col>

          <Col md={3}>
            <Row className="mb-3 align-items-center">
              <Button
                style={{ float: "right" }}
                size="sm"
                onClick={this.handleAddCaracter}
                variant="primary"
              >
                Agregar un Carácter
              </Button>
            </Row>

            <Row>
              {this.state.addCaracter && (
                <Navbar fixed="right">
                  <Nav.Item>
                    <Form onSubmit={this.onFormSubmitCaracter}>
                      <Form.Group controlId="name">
                        <Form.Label>Nombre:</Form.Label>
                        <Form.Control
                          type="text"
                          defaultValue={
                            this.state.editDirector
                              ? this.state.itemEdit.name
                              : ""
                          }
                        />
                      </Form.Group>
                      <Button
                        className="mr-2"
                        style={{ float: "left" }}
                        variant="primary"
                        type="submit"
                      >
                        Aceptar
                      </Button>
                      <Button
                        style={{ float: "right" }}
                        onClick={this.handleCloseAdd}
                        variant="secondary"
                      >
                        Cancelar
                      </Button>
                    </Form>
                  </Nav.Item>
                </Navbar>
              )}
            </Row>
          </Col>
        </Row>
      </Container>
    );
  }
}

export default SerieForm;
