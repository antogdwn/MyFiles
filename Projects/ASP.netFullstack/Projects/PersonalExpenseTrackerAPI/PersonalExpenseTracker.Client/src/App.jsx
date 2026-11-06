import { useState } from 'react'
import DisplayExpense  from './Components/ExpenseList'
import heroImg from './assets/hero.png'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)
//   const expenseList = [
//   { 
//     Id:1,
//     Title: 'Exp1', 
//     Amount: 40,
//     Category:'Food',
//     ExpenseDate :'2026-10-02',
//     Notes :'Notess',
//     UserId :1
//    },
//    { 
//     Id:2,
//     Title: 'Exp2', 
//     Amount: 100,
//     Category:'Travel',
//     ExpenseDate :'2026-10-03',
//     Notes :'New notes',
//     UserId :1},

// ];

// printing the values of array
  return (
    <>
    <DisplayExpense/>
    </>
  )
}

export default App
