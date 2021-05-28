import React, { Component } from "react";
import { Button } from "react-bootstrap";
import { PlusLg } from "react-bootstrap-icons";

class Add extends Component {
  state = {};
  render() {
    return (
      <Button
        className="mr-3"
        style={{ float: "right" }}
        onClick={this.props.onClick}
        variant="primary"
      >
        <PlusLg className="mr-2" />
        {this.props.text}
      </Button>
    );
  }
}

export default Add;
