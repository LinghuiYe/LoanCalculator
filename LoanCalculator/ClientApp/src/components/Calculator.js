import React, { useState, useEffect } from 'react';
import PaybackPlan from './PaybackPlan';
import './Calculator.css';

/**
 * General component for client input and a child component to show calculation results.
 */
const Calculator = () => {

    /** Use states for client input such as amount, interest, etc. */
    const [loanAmount, setLoanAmount] = useState(0);
    const [interest, setInterest] = useState(0);
    const [loanTypeId, setLoanTypeId] = useState(0);
    const [paybackYears, setPaybackYears] = useState(0);
    const [errorMessage, setErrorMessage] = useState(null);
    const [loanTypes, setLoanTypes] = useState([]);

    /** Call API to get valid loan types. */
    useEffect(() => {
        async function getLoans() {
            const response = await fetch('api/loantype');
            if (response.ok) {
                const data = await response.json();
                setLoanTypes(data);
            }
            else
            {
                alert("HTTP-Error:" + response.status)
                setLoanTypes([]);
            }
            
        }
        getLoans();
    }, []);

    /** Handling input value for loan amount. */
    const handleLoanAmountChange = event => {
        const amountInput = event.target.value;
        if (!isNaN(amountInput)) {
            setLoanAmount(amountInput);
        }
    };

    /** Handling input value for payback years. */
    const handlePaybackYearsChange = event => {
        const paybackYearsInput = event.target.value;
        if (!isNaN(paybackYearsInput)) {
            setPaybackYears(paybackYearsInput);
        }
    };

    /** Handling values from inputs, show error message if input is invalid. */
    const handleValue = event => {
        isNaN(event.target.value) || Number(event.target.value) <= 0
            ? setErrorMessage('Ugyldig verdi!')
            : setErrorMessage(null);
    };


    /** Handling select value for loan type. */
    const handleSelect = event => {
        const type = event.target.value;
        const loanType = loanTypes.find(e => e.name === type);
        if (loanType) {
            setInterest(loanType.value);
            setLoanTypeId(loanType.id);
        } else {
            setInterest(null);
            setLoanTypeId(0);
        }
    };

    return (
        <div>
            {/** Inputs from client. */}
            <div className="loanAmount">
                <h1>Ønsket lånebeløp</h1>
                <input name="loanAmountInput" type="number" onBlur={handleLoanAmountChange} onChange={handleValue} min="1" />
            </div>
            <div className="interest">
                <h1>Rente</h1>
                <select onChange={handleSelect}>
                    <option>Velg</option>
                    {
                        loanTypes.map((loanType, index) => {
                            return <option key={index}>{loanType.name}</option>
                        })
                    }
                </select>
                <div>
                    <label className="text">{interest}%</label>
                </div>
            </div>
            <div className="paybackYears">
                <h1>Løpetid</h1>
                <input name="paybackYearsInput" type="number" onBlur={handlePaybackYearsChange} onChange={handleValue} min="1" />
            </div>
            <label className="errorMsg">{errorMessage}</label>
            {/** Component to show payback plan with all calculation results. */}
            <PaybackPlan totalAmount={Number(loanAmount)} loanTypeId={Number(loanTypeId)} paybackYears={Number(paybackYears)} />
        </div>
    );

}
export default Calculator;