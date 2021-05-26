import React, { Component } from "react";
import { Container, Card, Nav, Table } from "react-bootstrap";
import Players from "../../components/Players/Players";
import Directors from "../../components/Directors/Directors";

class Team extends Component {
  state = {
    page: 1,
    name: "Industriales",
    directors: [
      {
        id: 1,
        name: "Lázaro Vargas",
        img: "http://localhost:8000/src/logos/lazaro-vargas.jpg",
      },
      {
        id: 2,
        name: "Rey Vicente Anglada",
        img: "http://localhost:8000/src/logos/anglada.jpg",
      },
    ],
    players: [
      {
        id: 1,
        name: "Alexander Malleta",
        positions: ["Primera base"],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_team: "Retirado",
        years_of_experience: 20,
        ave: 301,
      },
      {
        id: 2,
        name: "Frank Camilo Morejón",
        positions: ["Catcher"],
        img: "http://localhost:8000/src/logos/frank-camilo.jpg",
        age: 44,
        teams: ["Industriales"],
        current_team: "Retirado",
        years_of_experience: 17,
        ave: 253,
      },
    ],
    wonSeries: [
      { id: 1, name: "Serie Nacional de Bésibol", season: "2009-2010" },
    ],
  };

  handleOnClick = (p) => {
    this.setState({ page: p });
  };

  render() {
    const { idTeam } = this.props.location.state;
    return (
      <Container>
        <h1 className="mb-5 my-style-header">{this.state.name}</h1>
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
            {this.state.page === 1 && <Players players={this.state.players} />}
            {this.state.page === 2 && (
              <Directors directors={this.state.directors} />
            )}
            {this.state.page === 3 && (
              <Table striped bordered hover>
                <thead>
                  <th>Nombre</th>
                  <th>Temporada</th>
                </thead>
                <tbody>
                  {this.state.wonSeries.map((serie) => (
                    <tr>
                      <td>{serie.name}</td>
                      <td>{serie.season}</td>
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
