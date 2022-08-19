import React, { Component } from "react";
import { Card } from "./Card";

const suits = ['heart'];

const handleClickevent = () => {
    alert('time');
    console.log('yep');
}

export class Poker extends Component {
    static displayName = Poker.name;

    constructor(props) {
        super(props);
        this.state = {card1: {rank: "two", suit: "hearts"}};
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
      }


    
      handleChange(event) {    this.setState({value: event.target.value});  }
      handleSubmit(event) {
        alert('Your favorite flavor is: ' + this.state.value);
        event.preventDefault();
      }
    
      render() {
        return (
          <form >
            {/* <label>
                    Card 1
                    <Card card1={this.state.card1} />
                    
                </label> */}
                
                <button onClick={handleClickevent}>Go</button>
          </form>
          );
    }
    
    async handleClick() {
        const requestOptions = {
            method: 'POST',
            headers: {
                'Accept': 'text/plain',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                suite: "diamonds",
                rank: "king"
            })
        }
        const response = await fetch('https://localhost:7141/api/Poker', requestOptions)
            .then(response => response.json())
            .catch(function (error) {
            console.log(error);
        });
    
        //const data = await response.json();
        //this.setState({ forecasts: data, loading: false });
        //alert('abc: ' + data);    
    }
}