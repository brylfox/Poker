import { useState } from 'react';
import './App.css';
import Card from './Card';

function App() {

  const [game, setGame] = useState(
    {
      handOne: {
        owner: 'Bill',
        cards: [
          { id: "2D" },
          { id: "6C" },
          { id: "2H" },
          { id: "2C" },
          { id: "2S" },
        ]
      },
      handTwo: {
        owner: 'Ted',
        cards: [
          { id: "6D" },
          { id: "5C" },
          { id: "6H" },
          { id: "6C" },
          { id: "3S" },
        ]
      }
    }
  )

  const [result, setResult] = useState(
    {
      winner: {
        name: '',
        handRank: '',
        cardRank: ''
      },
      loser: {
        name: '',
        handRank: '',
        cardRank: ''
      }
    }
  )

  const { handOne, handTwo } = game;

  const handleDealClick = () => {
    // alert(JSON.stringify(game));
    console.log('yep');
    const requestOptions = {
      method: 'POST',
      headers: {
        'Accept': 'text/plain',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(game)
    };
    
    const response = fetch('https://localhost:7141/api/Poker', requestOptions)
      // .then(res => {
      //   if (res.ok) {
      //     alert('success');
          
      //   }
      //   res.json();
      // })
      .then(resp => resp.json())
      .then((data) => {
        console.log(data);
        const gameResult = { ...result };
        gameResult.winner.name = data.winner.hand.owner;
        gameResult.winner.cardRank = data.winner.cardRank;
        gameResult.winner.handRank = data.winner.handRank;
        gameResult.loser.name = data.loser.hand.owner;
        gameResult.loser.cardRank = data.loser.cardRank;
        gameResult.loser.handRank = data.loser.handRank;        
        setResult(gameResult);
      })
      .catch(function (error) {
      console.log(error);
    });
  }  


  // const handleChange = (e) => {
  //   alert('change occured');
  //   const { name, value } = e.target;
  //   alert(name + value)
  //   setGame({
  //     ...game,
  //     [game.handOne.owner]: value,
  //   });
  // };
  return (
    <div className="App">
      <div>
      <label>Player 1</label>
      <input
        type="text"
        required
        value={handOne.owner}
        onChange={(e) => setGame({
          ...game,
          handOne: {
            ...game.handOne,
            owner: e.target.value
          }
        })}>        
      </input><br></br>
      <label>Card 1</label>
      <input
        type="text" required maxLength={2}
        value={handOne.cards[0].id}
        onChange={e => {
          const g = { ...game };          
          g.handOne.cards[0].id = e.target.value;
          setGame(g);
        }}>
      </input><br></br>
      <label>Card 2</label>
      <input
        type="text" required maxLength={2}
        value={handOne.cards[1].id}
        onChange={e => {
          const g = { ...game };          
          g.handOne.cards[1].id = e.target.value;
          setGame(g);
        }}>
      </input><br></br>
      <label>Card 3</label>
      <input
        type="text" required maxLength={2}
        value={handOne.cards[2].id}
        onChange={e => {
          const g = { ...game };          
          g.handOne.cards[2].id = e.target.value;
          setGame(g);
        }}>
      </input><br></br>
      <label>Card 4</label>
      <input
        type="text" required maxLength={2}
        value={handOne.cards[3].id}
        onChange={e => {
          const g = { ...game };          
          g.handOne.cards[3].id = e.target.value;
          setGame(g);
        }}>
      </input><br></br>
      <label>Card 4</label>
      <input
          type="text" required maxLength={2}
          value={handOne.cards[4].id}
        onChange={e => {
          const g = { ...game };          
          g.handOne.cards[4].id = e.target.value;
          setGame(g);
        }}>
      </input>
      </div><br/><br/>

      <div>
        <label>Player 2</label>
        <input
          type="text"
          required
          value={handTwo.owner}
          onChange={(e) => setGame({
            ...game,
            handTwo: {
              ...game.handTwo,
              owner: e.target.value
            }
          })}>        
        </input><br></br>
        <label>Card 1</label>
        <input
          type="text" required maxLength={2}
          value={handTwo.cards[0].id}
          onChange={e => {
            const g = { ...game };          
            g.handTwo.cards[0].id = e.target.value;
            setGame(g);
          }}>
        </input><br></br>
        <label>Card 2</label>
        <input
          type="text" required maxLength={2}
          value={handTwo.cards[1].id}
          onChange={e => {
            const g = { ...game };          
            g.handTwo.cards[1].id = e.target.value;
            setGame(g);
          }}>
        </input><br></br>
        <label>Card 3</label>
        <input
          type="text" required maxLength={2}
          value={handTwo.cards[2].id}
          onChange={e => {
            const g = { ...game };          
            g.handTwo.cards[2].id = e.target.value;
            setGame(g);
          }}>
        </input><br></br>
        <label>Card 4</label>
        <input
          type="text" required maxLength={2}
          value={handTwo.cards[3].id}
          onChange={e => {
            const g = { ...game };          
            g.handTwo.cards[3].id = e.target.value;
            setGame(g);
          }}>
        </input><br></br>
        <label>Card 4</label>
        <input
            type="text" required maxLength={2}
            value={handTwo.cards[4].id}
          onChange={e => {
            const g = { ...game };          
            g.handTwo.cards[4].id = e.target.value;
            setGame(g);
          }}>
        </input>
      </div><br></br>
      <button onClick={handleDealClick}>Play</button>
      <br></br><br/>
      <div>
        <label>Winner: {result.winner.name}</label><br/>
        <label>Hand Rank: {result.winner.handRank}</label><br/>
        <label>Card Rank: {result.winner.cardRank}</label>
        <br /><br />
        <label>Loser: {result.loser.name}</label><br/>
        <label>Hand Rank: {result.loser.handRank}</label><br/>
        <label>Card Rank: {result.loser.cardRank}</label>
      </div>
      

    </div>
  );
}

export default App;
