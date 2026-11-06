import { getExpenses, updateExpense } from '../Service/expenseservice';
import { useEffect, useState } from 'react';
import { AddExpenseForm } from './AddExpenseForm';

function DisplayExpense() {
    const [expenseList, setExpenseList] = useState([]);
    const [editingExpense, setEditingExpense] = useState(null);
    const [isAddingExpense, setIsAddingExpense] = useState(false);
    const [isSaving, setIsSaving] = useState(false);
    const [updateError, setUpdateError] = useState('');

    function handleEditClick(expense) {
        setEditingExpense({ ...expense });
        setUpdateError('');
    }

    function handleEditFieldChange(event) {
        const { name, value } = event.target;
        setEditingExpense((currentExpense) => ({
            ...currentExpense,
            [name]: name === 'amount' ? Number(value) : value
        }));
    }

    async function handleUpdateExpense(event) {
        event.preventDefault();
        setIsSaving(true);
        setUpdateError('');

        try {
            const savedExpense = await updateExpense(editingExpense);

            // Replace the old row with the version saved by the API.
            setExpenseList((currentExpenses) =>
                currentExpenses.map((expense) =>
                    expense.id === savedExpense.id ? savedExpense : expense
                )
            );
            setEditingExpense(null);
        } catch (error) {
            setUpdateError(error.message);
        } finally {
            setIsSaving(false);
        }
    }

    useEffect(() => {
        getExpenses().then((expenses) => {
            setExpenseList(expenses);
        });
    }, []);

    return (
        <>
            <table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Amount</th>
                        <th>Category</th>
                        <th>Notes</th>
                        <th>Date</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {expenseList.map((expense) => (
                        <tr key={expense.id}>
                            <td>{expense.id}</td>
                            <td>{expense.title}</td>
                            <td>{expense.amount}</td>
                            <td>{expense.category}</td>
                            <td>{expense.notes}</td>
                            <td>{expense.expenseDate}</td>
                            <td>
                                <button
                                    type="button"
                                    onClick={() => handleEditClick(expense)}
                                >
                                    Edit
                                </button>
                                <button type="button">Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {!isAddingExpense && (
                <button
                    type="button"
                    onClick={() => setIsAddingExpense(true)}
                >
                    Add Expense
                </button>
            )}
            {isAddingExpense && (
                <AddExpenseForm
                    onExpenseAdded={(addedExpense) => {
                        setExpenseList((current) => [...current, addedExpense]);
                        setIsAddingExpense(false);
                    }}
                />
            )}

            {editingExpense && (
                <form onSubmit={handleUpdateExpense}>
                    <h2>Edit expense</h2>

                    <label htmlFor="edit-title">Title</label>
                    <input
                        id="edit-title"
                        name="title"
                        type="text"
                        value={editingExpense.title}
                        onChange={handleEditFieldChange}
                        required
                    />

                    <label htmlFor="edit-amount">Amount</label>
                    <input
                        id="edit-amount"
                        name="amount"
                        type="number"
                        min="0.01"
                        step="0.01"
                        value={editingExpense.amount}
                        onChange={handleEditFieldChange}
                        required
                    />

                    <label htmlFor="edit-category">Category</label>
                    <input
                        id="edit-category"
                        name="category"
                        type="text"
                        value={editingExpense.category}
                        onChange={handleEditFieldChange}
                        required
                    />

                    <label htmlFor="edit-notes">Notes</label>
                    <input
                        id="edit-notes"
                        name="notes"
                        type="text"
                        value={editingExpense.notes ?? ''}
                        onChange={handleEditFieldChange}
                    />

                    <label htmlFor="edit-date">Date</label>
                    <input
                        id="edit-date"
                        name="expenseDate"
                        type="date"
                        value={editingExpense.expenseDate}
                        onChange={handleEditFieldChange}
                        required
                    />

                    {updateError && <p role="alert">{updateError}</p>}

                    <button type="submit" disabled={isSaving}>
                        {isSaving ? 'Saving...' : 'Save changes'}
                    </button>
                    <button
                        type="button"
                        onClick={() => {
                            setEditingExpense(null);
                            setUpdateError('');
                        }}
                        disabled={isSaving}
                    >
                        Cancel
                    </button>
                </form>
            )}
        </>
    );
}

export default DisplayExpense;