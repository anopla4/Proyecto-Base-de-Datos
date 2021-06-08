import React, { Component } from "react";
import { Container, Card, Nav, Table } from "react-bootstrap";
import Players from "../../components/Players/Players";
import Directors from "../../components/Directors/Directors";

class Team extends Component {
  state = {
    page: 1,
    team: {},
    directors: [],
    players: [],
    wonSeries: [],
  };

  handleOnClick = (p) => {
    this.setState({ page: p });
  };

  componentWillMount() {
    this.setState({ team: this.props.location.state.team });
  }
  formatDate = (date) => {
    let d = new Date(date);
    return `${d.getFullYear()}-${d.getMonth() + 1}-${d.getDate()}`;
  };

  componentDidMount() {
    fetch(
      `https://localhost:44334/api/TeamSerieDirector/${this.state.team.id}`,
      { mode: "cors" }
    )
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
    fetch(
      `https://localhost:44334/api/TeamSerie/TeamWonSeries/${this.state.team.id}`,
      {
        mode: "cors",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ wonSeries: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch(
      `https://localhost:44334/api/TeamSeriePlayer/Team/${this.state.team.id}`,
      {
        mode: "cors",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ players: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  render() {
    const { name, initials, color, imgPath } = this.props.location.state;
    return (
      <Container>
        <h1 className="mb-5 my-style-header">{name}</h1>
        <Card>
          <Card.Header>
            <Nav variant="tabs" defaultActiveKey={1}>
              <Nav.Item onClick={() => this.handleOnClick(1)} key={1}>
                <Nav.Link>Jugadores</Nav.Link>
              </Nav.Item>
              <Nav.Item onClick={() => this.handleOnClick(2)} key={2}>
                <Nav.Link>Directores</Nav.Link>
              </Nav.Item>
              <Nav.Item onClick={() => this.handleOnClick(3)} key={3}>
                <Nav.Link>Series Ganadas</Nav.Link>
              </Nav.Item>
            </Nav>
          </Card.Header>
          <Card.Body>
            {this.state.page === 1 && (
              <Players playerGeneral={false} players={this.state.players} />
            )}
            {this.state.page === 2 && (
              <Directors directors={this.state.directors} />
            )}
            {this.state.page === 3 && (
              <Table striped bordered hover>
                <thead>
                  <th>Nombre</th>
                  <th>Fecha de inicio</th>
                  <th>Fecha de culminación</th>
                </thead>
                <tbody>
                  {this.state.wonSeries.map((serie) => (
                    <tr>
                      <td>{serie.name}</td>
                      <td>
                        {
                          new Date(serie.initDate)
                            .toLocaleString()
                            .split(",")[0]
                        }
                      </td>
                      <td>
                        {new Date(serie.endDate).toLocaleString().split(",")[0]}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </Table>
            )}
          </Card.Body>
        </Card>
      </Container>
    );
  }
}

export default Team;
