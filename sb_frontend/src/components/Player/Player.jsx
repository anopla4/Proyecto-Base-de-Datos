import React, { Component } from "react";
import { Media } from "react-bootstrap";
import "./Player.css";
class Player extends Component {
  state = {
    player: {
      id: 1,
      name: "Alexander Malleta",
      img: "http://localhost:8000/src/logos/malleta.jpg",
      description:
        "Alexander Malleta (La Habana, Cuba, 22 de enero de 1977) es un jugador de béisbol cubano. Actúa como primera base para el equipo Industriales, y ha integrado varias veces la Selección de béisbol de Cuba. Ha participado en 13 Series Nacionales, alcanzando 3 títulos, todos con Industriales y siendo elegido el MVP (jugador más valioso) de las post-temporadas del 2006 y 2010, coincidiendo con los últimos campeonatos conquistados por Industriales. Con el equipo Cuba obtuvo la medalla de plata en los Juegos Olímpicos de Pekín 2008 y participó en el Clásico Mundial de Béisbol 2009.",
    },
  };
  render() {
    console.log(this.props);
    const { idPlayer } = this.props.location.state;
    return (
      <Media className="mt-5">
        <img
          width={120}
          height={120}
          className="mr-3"
          src={this.state.player.img}
          alt=""
        />
        <Media.Body>
          <h5>{this.state.player.name}</h5>
          <p>{this.state.player.description}</p>
        </Media.Body>
      </Media>
    );
  }
}

export default Player;
