import React, { Component } from "react";
import {
  Container,
  Button,
  Form,
  Navbar,
  Nav,
  Row,
  Col,
  Image,
} from "react-bootstrap";
import "../../containers/App/App.css";
import Directors from "../../components/Directors/Directors";
import Add from "../../components/Add/Add";

class DirectorsGeneral extends Component {
  state = {
    logged: localStorage.getItem("loggedUser"),
    addDirector: false,
    editDirector: false,
    itemEdit: {},
    directors: [],
    file: undefined,
    fileTmpURL: undefined,
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
      headers: { "Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token },
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

  setFile = (e) => {
    let f_url = URL.createObjectURL(e.target.files[0]);
    this.setState({
      fileTmpURL: f_url,
      file: e.target.files[0],
    });
  };

  onFormSubmit = (e) => {
    let formElements = e.target.elements;
    const name = formElements.name.value;
    var formdata = new FormData();
    formdata.append("name", name);
    formdata.append("img", this.state.file, this.state.file.name);

    var requestOptions = {
      method: this.state.editDirector ? "PATCH" : "POST",
      body: formdata,
      mode: "cors",
      headers: { "Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token },

    };

    let postUrl =
      "https://localhost:44334/api/Director" +
      (this.state.editDirector ? `/${this.state.itemEdit.id}` : "");
    console.log(postUrl);
    fetch(postUrl, requestOptions)
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    this.setState({ addDirector: false, editDirector: false });
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
    // if (this.state.editDirector) {
    //   fetch(`https://localhost:44334/${this.state.itemEdit.imgPath}`).then(
    //     (res) => {
    //       let file = res.blob();
    //       let fileTmpURL = URL.createObjectURL(file);
    //       this.setState({
    //         file: file,
    //         fileTmpUrl: fileTmpURL,
    //       });
    //     }
    //   );
    // }
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
          {this.state.logged && (this.state.addDirector || this.state.editDirector) && (
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
                    <Form.Group controlId="img">
                      <Image
                        src={
                          this.state.fileTmpURL
                            ? this.state.fileTmpURL
                            : `https://localhost:44334/${this.state.itemEdit.imgPath}`
                        }
                      />
                      <Form.File
                        label="Foto del director"
                        onChange={(e) => this.setFile(e)}
                      />
                    </Form.Group>
                    <Button
                      className="mr-2"
                      style={{ float: "left" }}
                      variant="primary"
                      type="submit"
                      // onClick={this.onFormSubmit}
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
