import API_BASE_URL from '../Config/Api';

 
export async function getExpenses() 
{
    const response =await fetch(`${API_BASE_URL}/expense`);
    if (!response.ok) {
        throw new Error('Failed to fetch expenses');
    }
    return response.json();
}
export async function addExpense(frmexpense) {
    const response = await fetch(`${API_BASE_URL}/expense`,{
        method: "Post",
        headers :{
            "Content-Type": "application/json"
        },
        body:JSON.stringify(frmexpense)
    })
    if(!response.ok){
        throw new Error('Failed to add expense');
    }
    const data = await response.json();
    return data;
}

export async function updateExpense(updatedExpense){
    const response =await fetch(`${API_BASE_URL}/expense`,{
        method:"PUT",
        headers:{
            "Content-Type" :"application/json"
        },
        body :JSON.stringify(updatedExpense)

    })
    if(!response.ok){
        throw new Error('Failed to update expense');
    }
    const data = await response.json();
    return data;
}
