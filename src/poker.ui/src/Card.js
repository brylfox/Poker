import { useState } from "react";

const Card = (card) => {
    
    return (
        <div>
        <select value={card.suit}>
            <option value="hearts">Hearts</option>
            <option value="diamonds">Diamonds</option>
            <option value="spades">Spades</option>
            <option value="clubs">Clubs</option>
            </select>
            </div>
    );
}

export default Card;

// import React, { Component } from "react";

// export class Card extends Component {
//     static displayName = Card.name;

//     constructor(props) {
//         super(props);
//         this.state = { suite: 'Hearts', rank: 'two' };
//         this.handleSuiteChange = this.handleSuiteChange.bind(this);
//         this.handleRankChange = this.handleRankChange.bind(this);
//     }

//     handleSuiteChange(event) { this.setState({ suite: event.target.value }); }
//     handleRankChange(event) { this.setState({rank: event.target.value});  }
//     render() {
//         return (
//             <form>
//                 <select value={this.state.suite} onChange={this.handleSuiteChange}>
//                     <option value="hearts">Hearts</option>
//                     <option value="diamonds">Diamonds</option>
//                     <option value="spades">Spades</option>
//                     <option value="clubs">Clubs</option>
//                 </select>
//                 <select value={this.state.rank} onChange={this.handleRankChange}>
//                     <option value="two">2</option>
//                     <option value="three">3</option>
//                     <option value="four">4</option>
//                     <option value="five">5</option>
//                 </select>
//             </form>
//         );
//     }
// }