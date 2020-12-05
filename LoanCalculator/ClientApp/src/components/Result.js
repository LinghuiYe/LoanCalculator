import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import './Result.css';

const Result = ({
    totalAmount,
    interest,
    paybackTime,
}) => {

    const [monthlyAmount, setMonthlyAmount] = useState(0);

    useEffect(() => {
        if (totalAmount > 0 && interest > 0 && paybackTime > 0) {
            async function calculateMonthlyAmount() {
                const response = await fetch('api/loans/calculate', {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ Amount: totalAmount, Interest: interest, PaybackTime: paybackTime })
                });
                console.log(response);
                const data = await response.json();
                setMonthlyAmount(data);
            }
            calculateMonthlyAmount();
        }
    }, [totalAmount, interest, paybackTime]);

    return (
        <div className="result">
            <h1>Du må betale <span className="text">{monthlyAmount}</span> kr/mnd</h1>
        </div>
    );
};

Result.propTypes = {
    totalAmount: PropTypes.number,
    interest: PropTypes.number,
    paybackTime: PropTypes.number,
};

export default Result;