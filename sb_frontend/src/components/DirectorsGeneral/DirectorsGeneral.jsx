import React, { Component } from "react";
import {
  Container,
  Button,
  Form,
  Navbar,
  Nav,
  Row,
  Col,
} from "react-bootstrap";
import "../../containers/App/App.css";
import Directors from "../../components/Directors/Directors";
import Add from "../../components/Add/Add";

class DirectorsGeneral extends Component {
  state = {
    addDirector: false,
    editDirector: false,
    itemEdit: {},
    directors: [
      {
        id: 1,
        name: "Víctor Mesa",
        img: "http://localhost:8000/src/logos/victor-mesa.jpg",
        directed_teams: ["Villa Clara", "Matanzas", "Cuba"],
      },
      {
        id: 2,
        name: "Alfonso Urquiola",
        img: "http://localhost:8000/src/logos/Alfonso_Urquiola_Crespo.jpg",
        directed_teams: ["Pinar del Río", "Cuba"],
      },
    ],
  };

  handleAddClick = () => {
    this.setState({ addDirector: true, editDirector: false, itemEdit: {} });
  };

  handleEditClick = (director) => {
    this.setState({
      addDirector: false,
      editDirector: true,
      itemEdit: director,
    });
  };

  handleCloseAdd = () => {
    this.setState({ editDirector: false, addDirector: false, itemEdit: {} });
  };

  componentDidMount() {
    fetch("https://localhost:44334/api/Director", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ directors: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  render() {
    return (
      <Container className="list-unstyled">
        <h1 className="mb-5 my-style-header">Directores de béisbol</h1>
        <Row>
          <Col>
            <Directors
              delete={true}
              edit={true}
              onEdit={this.handleEditClick}
              directors={this.state.directors}
            />
            <Add text="Agregar director" onClick={this.handleAddClick} />
          </Col>
          {(this.state.addDirector || this.state.editDirector) && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form>
                    <Form.Group controlId="name">
                      <Form.Label>Nombre:</Form.Label>
                      <Form.Control
                        type="text"
                        value={
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
            </Col>
          )}
        </Row>
      </Container>
    );
  }
}

export default DirectorsGeneral;
