import React, { Component } from "react";
import { Form, Button, Row, Col, Container, Image } from "react-bootstrap";
import "./PlayerForm.css";

class PlayerForm extends Component {
  state = {
    edit: false,
    playerEdit: {},
    selectedPositions: [],
    hands: ["Izquierda", "Derecha"],
    positions: [],
    teams: [],
    file: undefined,
    fileTmpURL: undefined,
  };
  onChange = (e) => {
    e.preventDefault();
    if (this.state.selectedPositions.includes(e.target.value)) {
      this.setState((prevState) => ({
        selectedPositions: [
          ...prevState.selectedPositions.filter(
            (item) => item !== e.target.value
          ),
        ],
      }));
    } else {
      let index = e.target.selectedIndex;
      let el = e.target.childNodes[index];
      let option = el.getAttribute("id");
      this.setState((prevState) => ({
        selectedPositions: [...prevState.selectedPositions, option],
      }));
    }
  };

  componentWillMount() {
    fetch("https://localhost:44334/api/Position", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ positions: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch("https://localhost:44334/api/Team", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ teams: response });
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
    const positions = [
      ...this.state.positions.filter((c) =>
        this.state.selectedPositions.includes(c.id)
      ),
    ];
    const current_Team = formElements.current_Team;
    const current_TeamId = current_Team.children[current_Team.selectedIndex].id;
    const age = formElements.age.value;
    const year_Experience = formElements.year_Experience.value;
    const deffAverage = formElements.deffAverage.value;
    const era = formElements.era.value;
    const average = formElements.average.disabled
      ? ""
      : formElements.average.value;
    // const era = formElements.era.disabled ? "" : formElements.era.value;
    const hand = formElements.hand.disabled ? "" : formElements.hand.value;
    let player = {
      name,
      positions,
      current_TeamId,
      age,
      year_Experience,
      deffAverage,
    };

    if (era !== "") {
      player = { ...player, era };
    }
    if (hand !== "") {
      player = { ...player, hand };
    }
    if (average !== "") {
      player = { ...player, average };
    }

    let postUrl =
      "https://localhost:44334/api/Player" +
      (this.state.edit ? `/${this.state.playerEdit.id}` : "");
    fetch(postUrl, {
      mode: "cors",
      headers: { "Content-Type": "application/json" },
      method: this.state.edit ? "PATCH" : "POST",
      body: JSON.stringify(player),
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
    this.props.history.push({ pathname: "/players", state: { edited: true } });
  };

  render() {
    const {
      id,
      name,
      // img,
      age,
      year_Experience,
      current_Team,
      era,
      hand,
      positions,
      deffAverage,
      average,
    } = {
      ...this.props.location.state.player,
    };
    console.log(this.state.selectedPositions);
    return (
      <Container alignSelf="center" className="mt-4">
        <h1 className="mb-5 my-style-header">Jugador</h1>

        <Col className="center">
          <Form
            onSubmit={this.onFormSubmit}
            style={{ width: "70%", alignItems: "center" }}
          >
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="name">
                  <Form.Label>Nombre:</Form.Label>
                  <Form.Control type="text" defaultValue={name ? name : ""} />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group>
                  <Image
                    src={
                      this.state.fileTmpURL
                        ? this.state.fileTmpURL
                        : `https://localhost:44334/${this.state.playerEdit.imgPath}`
                    }
                  />
                  <Form.File id="img" label="Imagen del jugador" />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="current_Team">
                  <Form.Label>Equipo actual:</Form.Label>
                  <Form.Control
                    defaultValue={current_Team ? current_Team : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    <option>{"Retirado"}</option>
                    {this.state.teams.map((team) => (
                      <option id={team.id}>{team.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="age">
                  <Form.Label>Edad:</Form.Label>
                  <Form.Control
                    defaultValue={age ? age : ""}
                    type="numeric"
                    name="age"
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="year_Experience">
                  <Form.Label>Años de experiencia:</Form.Label>
                  <Form.Control
                    defaultValue={year_Experience ? year_Experience : ""}
                    type="numeric"
                    name="year_Experience"
                  />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group controlId="positions">
                  <Form.Label>Posición:</Form.Label>
                  <Form.Control
                    defaultValue={
                      positions
                        ? positions.map((pos) => pos.positionName)
                        : undefined
                    }
                    as="select"
                    onChange={this.onChange}
                    custom
                    multiple
                  >
                    <option>{""}</option>
                    {this.state.positions.map((pos) => (
                      <option id={pos.id}>{pos.positionName}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="hand">
                  <Form.Label>Mano:</Form.Label>
                  <Form.Control
                    defaultValue={hand ? hand : ""}
                    as="select"
                    custom
                    disabled={
                      !this.state.selectedPositions.includes("P") ? true : false
                    }
                  >
                    <option>{""}</option>
                    {this.state.hands.map((hand) => (
                      <option>{hand}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group controlId="deffAverage">
                  <Form.Label>Average defensivo:</Form.Label>
                  <Form.Control
                    defaultValue={deffAverage ? deffAverage : ""}
                    type="numeric"
                    name="deffAverage"
                    s
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="era">
                  <Form.Label>Promedio de carreras limpias:</Form.Label>
                  <Form.Control
                    defaultValue={era ? era : ""}
                    type="numeric"
                    name="era"
                    disabled={
                      !this.state.selectedPositions.includes("P") ? true : false
                    }
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="average">
                  <Form.Label>Average:</Form.Label>
                  <Form.Control
                    defaultValue={average ? average : ""}
                    type="numeric"
                    name="average"
                    disabled={
                      this.state.selectedPositions.includes("P") &&
                      this.state.selectedPositions.length === 1
                        ? true
                        : false
                    }
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

export default PlayerForm;
