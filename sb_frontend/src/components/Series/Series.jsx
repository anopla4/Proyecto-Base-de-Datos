import React, { Component } from "react";
import { Table } from "react-bootstrap";

class Series extends Component {
  state = {
    series: [
      {
        id: 1,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1994-1995",
        ng: "50",
        nt: "15",
      },
      {
        id: 2,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1996-1997",
        ng: "40",
        nt: "15",
      },
      {
        id: 3,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1997-1998",
        ng: "30",
        nt: "15",
      },
    ],
  };
  render() {
    return (
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Temporada</th>
            <th>Carácter</th>
            <th>Cantidad de juegos</th>
            <th>Cantidad de equipos</th>
          </tr>
        </thead>
        {this.state.series.map((serie) => (
          <tr key={serie.id}>
            <td>{serie.name}</td>
            <td>{serie.season}</td>
            <td>{serie.reach}</td>
            <td>{serie.ng}</td>
            <td>{serie.nt}</td>
          </tr>
        ))}
      </Table>
    );
  }
}

export default Series;
