import{addExpense} from '../Service/expenseservice';
import { useState } from 'react';

export function AddExpenseForm({ onExpenseAdded }) {
    const[frmexpense,setfrmExpense] =useState({
        title:'',
        amount:0,
        category:'',
        notes:'',
        expenseDate:'',
        userId:0
    });
    async function handleAddExpense() {
        const res =await addExpense(frmexpense);
        await onExpenseAdded(res);
    }
    return (
       <form>
        <input type="text" 
        placeholder="Title" 
        value={frmexpense.title}
        onChange ={(e) =>
            setfrmExpense({...frmexpense,title:e.target.value})}
        />
        <input type="number" placeholder="Amount" 
            value={frmexpense.amount}
            onChange ={(e) => setfrmExpense({...frmexpense,amount:Number(e.target.value)})}
            />
        <input type="text" placeholder="Category" 
            value={frmexpense.category}
            onChange ={(e) => setfrmExpense({...frmexpense,category:e.target.value})}
            />
        <input type="text" placeholder="Notes" 
            value={frmexpense.notes}
            onChange ={(e) => setfrmExpense({...frmexpense,notes:e.target.value})}
            />
        <input type="date" placeholder="Expense Date" 
            value={frmexpense.expenseDate}
            onChange ={(e) => setfrmExpense({...frmexpense,expenseDate:e.target.value})}
            />
        <input type="number" placeholder="User Id" 
            value={frmexpense.userId}
            onChange ={(e) => setfrmExpense({...frmexpense,userId:Number(e.target.value)})}
            />
        <button type="button" onClick={handleAddExpense}>Add Expense</button>
       </form>
    )
}


