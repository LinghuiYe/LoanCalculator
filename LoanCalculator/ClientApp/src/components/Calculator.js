import React, { useState, useEffect } from 'react';
import PaybackPlan from './PaybackPlan';
import './Calculator.css';

const Calculator = () => {

    const [amount, setAmount] = useState(0);
    const [interest, setInterest] = useState(0);
    const [loanTypeId, setLoanTypeId] = useState(0);
    const [paybackTime, setPaybackTime] = useState(0);
    const [errorMessage, setErrorMessage] = useState(null);
    const [loanTypes, setLoanTypes] = useState([]);

    useEffect(() => {
        async function getLoans() {
            const response = await fetch('api/loantype');
            const data = await response.json();
            setLoanTypes(data);
        }
        getLoans();
    }, []);

    const handleAmountChange = event => {
        const amountInput = event.target.value;
        if (!isNaN(amountInput)) {
            setAmount(amountInput);
        }
    };

    const handlePaybackTimeChange = event => {
        const paybackTimeInput = event.target.value;
        if (!isNaN(paybackTimeInput)) {
            setPaybackTime(paybackTimeInput);
        }
    };

    const handleValue = event => {
        isNaN(event.target.value) ? setErrorMessage('Ugyldig verdi!') : setErrorMessage(null);
    };

    const handleSelect = event => {
        const type = event.target.value;
        const loanType = loanTypes.find(e => e.name === type);
        if (loanType) {
            setInterest(loanType.value);
            setLoanTypeId(loanType.id);
        } else {
            setInterest(null);
        }
    };

    return (
        <div>
            <div className="amount">
                <h1>Ønsket lånebeløp</h1>
                <input name="loanAmountInput" type="text" onBlur={handleAmountChange} onChange={handleValue} />
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
            <div className="paybackTime">
                <h1>Løpetid</h1>
                <input name="paybackTimeInput" type="text" onBlur={handlePaybackTimeChange} onChange={handleValue} />
            </div>
            <label>{errorMessage}</label>
            <PaybackPlan totalAmount={Number(amount)} loanTypeId={Number(loanTypeId)} paybackTime={Number(paybackTime)} />
        </div>
    );

}
export default Calculator;