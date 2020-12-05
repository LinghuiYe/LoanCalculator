import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import './PaybackPlan.css';

const PaybackPlan = ({
    totalAmount,
    interest,
    paybackTime,
}) => {

    const [plan, setPlan] = useState([]);

    useEffect(() => {
        if (totalAmount > 0 && interest > 0 && paybackTime > 0) {
            async function getPaybackPlan() {
                const response = await fetch('api/loans/plan', {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ Amount: totalAmount, Interest: interest, PaybackTime: paybackTime })
                });
                console.log(response);
                const data = await response.json();
                setPlan(data);
            }
            getPaybackPlan();
        }
    }, [totalAmount, interest, paybackTime]);

    return (
        <div>
            <h1>Nedbetalingsplan</h1>
            <div className="planContainer">
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Dato</th>
                        <th>Beløp</th>
                        <th>Avgift</th>
                        <th>Restgjelder</th>
                    </tr>
                </thead>
                <tbody>
                    {plan.map(p =>
                        <tr key={p.paybackDate}>
                            <td>{p.paybackDate}</td>
                            <td>{p.amount}</td>
                            <td>{p.interestFee}</td>
                            <td>{p.restDebt}</td>
                        </tr>
                    )}
                </tbody>
                </table>
            </div>
        </div>
    );
};

PaybackPlan.propTypes = {
    totalAmount: PropTypes.number,
    interest: PropTypes.number,
    paybackTime: PropTypes.number,
};

export default PaybackPlan;