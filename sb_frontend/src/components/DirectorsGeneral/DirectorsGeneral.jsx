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
    directors: [],
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

  handleOnDelete = (id, index) => {
    fetch(`https://localhost:44334/api/Director/${id}`, {
      mode: "cors",
      method: "DELETE",
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

    let n_directors = [...this.state.directors];
    n_directors.splice(index, 1);

    this.setState({ directors: n_directors });
  };

  onFormSubmit = (e) => {
    let formElements = e.target.elements;
    const name = formElements.name.value;
    let director = {
      name,
    };
    let postUrl =
      "https://localhost:44334/api/Director" +
      (this.state.editDirector ? `/${this.state.itemEdit.id}` : "");
    fetch(postUrl, {
      mode: "cors",
      headers: { "Content-Type": "application/json" },
      method: this.state.editDirector ? "PATCH" : "POST",
      body: JSON.stringify(director),
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
              onDelete={this.handleOnDelete}
              directors={this.state.directors}
            />
            <Add text="Agregar director" onClick={this.handleAddClick} />
          </Col>
          {(this.state.addDirector || this.state.editDirector) && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form onSubmit={this.onFormSubmit}>
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
            </Col>
          )}
        </Row>
      </Container>
    );
  }
}

export default DirectorsGeneral;
