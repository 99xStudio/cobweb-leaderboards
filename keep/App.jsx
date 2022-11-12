import './App.css'
import { getLeaderboardByGUID, addNewEntry } from "./Api"
import { useState, useEffect } from 'react'

export const App = () => {
  const [lb, setLb] = useState()
  const targetLb = "me.rd9.challengemod"

  async function getNewData() {
    let els = []
    let newData = await getLeaderboardByGUID(targetLb)
    newData.forEach(entry => {
      let entryDate = new Date(entry.created_at)
      let dateString = <>[{entryDate.getDate()}/{entryDate.getMonth() + 1}/{entryDate.getFullYear()} @ {entryDate.getHours()}:{entryDate.getMinutes()}]</>
      els.push(<div className='lb-entry' key={entry.id}>{entry.player_name} - {entry.score} - {dateString}</div>)
    })
    setLb(els)
  }

  async function addTestData() {
    await addNewEntry(targetLb, 3, "reddust9")
  }

  useEffect(() => {
    getNewData()
  })

  return (
    <div className="App">
      <div className='controls'>
        <button onClick={getNewData}>Update</button>
        &nbsp;  
        <span>Leaderboard for {targetLb}</span>
      </div>
      <div id="lb-container">
        {lb}
      </div>
    </div>
  )
}
