import "./RollDragon.css"
import "./Home.css"
import { getLeaderboardByGUID, getAllLeaderboardMods } from "../Api"
import { useEffect, useState, useRef } from "react"

export default function Home() {
    var mods = [] 
    const [options, setOptions] = useState([])
    const [lb, setLb] = useState([])
    const modSelectRef = useRef()

    function onlyUniqueFilter(value, index, self) {
        return self.indexOf(value) === index;
      }

    async function updateModSelector() {
        mods = []
        var data = await getAllLeaderboardMods()
        data.forEach(o => {
            mods.push(o.mod_guid)
        })
        mods = mods.filter(onlyUniqueFilter)

        var els = []
        mods.forEach((mod, i) => {
            els.push(<option key={i} value={mod}>{mod}</option>)
        })
        setOptions(els)
    }
    async function updateLeaderboard() {
        var data = await getLeaderboardByGUID(modSelectRef.current.value)

        var dates = []
        data.forEach(score => {
            dates.push(score.created_at)
        })
        dates.filter(onlyUniqueFilter)

        var els = []
        data.forEach((score, i) => {
            var d = new Date(score.created_at)
            var dstring = `${d.getDate()}/${d.getMonth() + 1}/${d.getFullYear()}`
            var tstring = `${d.getHours()}:${d.getMinutes()}:${d.getSeconds()}`
            var el = <p key={i}>
                <span className="box-0">{dstring}</span>
                <span className="box-0">{tstring}</span>
                <span className="box-1">{score.score}</span>
                <span className="box-2">{score.player_name}</span>
            </p>
            els.push(el)
        })
        setLb(els)
    }

    useEffect(() => {
        async function update() {
            await updateModSelector()
            await updateLeaderboard()
            await updateLeaderboard()
        }
        update()
    }, [])

    return <><div className="container">
        <section className="input-wrap">
            <label htmlFor="mod-select">Select a mod: </label>
            <select onChange={updateLeaderboard} ref={modSelectRef} name="mod-select" id="mod-select">
                {options}
            </select>
        </section>
    </div>
    <br />
    <div className="container">
        <section className="text-wrap">
            {lb}
        </section>
    </div>
    </>
}