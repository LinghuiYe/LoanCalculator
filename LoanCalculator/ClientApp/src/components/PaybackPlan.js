import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import './PaybackPlan.css';

/**
 * Component to show pay back plan with all calculated results.
 */
const PaybackPlan = ({
    totalAmount,
    loanTypeId,
    paybackTime,
}) => {

    /** Use states for payback plans. */
    const [plan, setPlan] = useState([]);

    /** Call API to get an array of payback plans. */
    useEffect(() => {
        if (totalAmount > 0 && loanTypeId > 0 && paybackTime > 0) {
            async function getPaybackPlan() {
                const response = await fetch('api/payplan', {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ LoanAmount: totalAmount, LoanType: loanTypeId, PaybackYears: paybackTime })
                });
                const data = await response.json();
                setPlan(data);
            }
            getPaybackPlan();
        }
    }, [totalAmount, loanTypeId, paybackTime]);

    return (
        <div>
            {/** Show the amount should be paid monthly. */}
            <div className="result">
                <h1>Du må betale <span className="text">{plan[0]?.monthlyPayTotal}</span> kr/mnd</h1>
            </div>
            {/** Show the schema of payback plan includes date, amount, interest, etc. */}
            <h1>Nedbetalingsplan</h1>
            <div className="planContainer">
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Dato</th>
                            <th>Beløp</th>
                            <th>Renter</th>
                            <th>Å betale</th>
                            <th>Restgjelder</th>
                        </tr>
                    </thead>
                    <tbody>
                        {plan.map((p, index) =>
                            <tr key={index}>
                                <td>{p.paybackDate}</td>
                                <td>{p.monthlyPayAmount}</td>
                                <td>{p.monthlyPayInterest}</td>
                                <td>{p.monthlyPayTotal}</td>
                                <td>{p.outstandingDebt}</td>
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
    loanTypeId: PropTypes.number,
    paybackTime: PropTypes.number,
};

export default PaybackPlan;