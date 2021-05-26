import React, { Component } from "react";
import { Table, Container, Button } from "react-bootstrap";
import "./Series.css";
class Series extends Component {
  state = {
    redirect: null,
    series: [
      {
        id: 1,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1994-1995",
        ng: "50",
        nt: "15",
        winner: "Industriales",
        loser: "Isla de la Juventud",
      },
      {
        id: 2,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1996-1997",
        ng: "40",
        nt: "15",
        winner: "Matanzas",
        loser: "Las Tunas",
      },
      {
        id: 3,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1997-1998",
        ng: "30",
        nt: "15",
        winner: "Industriales",
        loser: "Guantánamo",
      },
    ],
  };
  handleOnClick = (id, name) => {
    // this.setState({ redirect: "/serie" });
    // fetch serie data from data base
    this.props.history.push({
      pathname: "/serie",
      state: {
        serie: {
          id: id,
          name: name,
          standings: [
            {
              team: {
                id: 1,
                img: "http://localhost:8000/src/logos/industriales.png",
                name: "Industriales",
              },
              won_games: 30,
              lost_games: 10,
            },
            {
              team: {
                id: 2,
                img: "http://localhost:8000/src/logos/cienfuegos.png",
                name: "Cienfuegos",
              },
              won_games: 27,
              lost_games: 8,
            },
            {
              team: {
                id: 1,
                img: "http://localhost:8000/src/logos/ciego.png",
                name: "Ciego de Ávila",
              },
              won_games: 24,
              lost_games: 10,
            },
          ],
          allstarteams: [
            {
              id: 1,
              name: "Alexander Malleta",
              img: "http://localhost:8000/src/logos/malleta.jpg",
              position: "Primera Base",
            },
            {
              id: 2,
              name: "Pedro Luis Lazo",
              img: "http://localhost:8000/src/logos/pedro_luis_lazo.jpg",
              position: "Pitcher",
            },
            {
              id: 3,
              name: "Frank Camilo Morejón",
              img: "http://localhost:8000/src/logos/frank-camilo.jpg",
              position: "Catcher",
            },
          ],
        },
      },
    });
  };

  handleOnClickButton = () => {
    this.props.history.push("/serieForm");
  };

  render() {
    // if (this.state.redirect) {
    //   return <Redirect to={this.state.redirect}></Redirect>;
    // }
    return (
      <Container>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Nombre</th>
              <th>Temporada</th>
              <th>Carácter</th>
              <th>Cantidad de juegos</th>
              <th>Cantidad de equipos</th>
              <th>Primer lugar</th>
              <th>Último lugar</th>
            </tr>
          </thead>
          <tbody>
            {this.state.series.map((serie) => (
              <tr
                key={serie.id}
                onClick={() => this.handleOnClick(serie.id, serie.name)}
              >
                <td>{serie.name}</td>
                <td>{serie.season}</td>
                <td>{serie.reach}</td>
                <td>{serie.ng}</td>
                <td>{serie.nt}</td>
                <td>{serie.winner}</td>
                <td>{serie.loser}</td>
              </tr>
            ))}
          </tbody>
        </Table>
        <Button
          style={{ float: "right" }}
          onClick={this.handleOnClickButton}
          variant="primary"
        >
          Agregar Serie
        </Button>
      </Container>
    );
  }
}

export default Series;
