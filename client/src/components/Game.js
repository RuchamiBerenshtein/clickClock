import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import axios from "axios";
import Navigation from "./Navigation";
import { Radio, Input, Space } from 'antd';

function Game() {

    const [value, setValue] = useState(1);

    const baseURL = "https://localhost:44345/api/questions/1";

    const [question, setQuestion] = useState("");
    const [answers, setAnswers] = useState([]);

    const requests = (async () => {
        try {
            const thisQuestion = await (await axios.get(baseURL)).data
            setQuestion = thisQuestion.theQuestion
            setAnswers = thisQuestion.answers;
        }
        catch (error) {
            setOptionA = "Hello World!"
        }
    });

    requests()

    return (
        <div>
            <Navigation />
            <br></br>
            <div>Game!!!</div>
            <Radio.Group onChange={(e) => setValue(e.target.value)}>
                <Space direction="vertical">
                    <Radio value={1}>{optionA}</Radio>
                    <Radio value={2}>{optionB}</Radio>
                    <Radio value={3}>{optionC} </Radio>
                    <Radio value={4}>
                        More...
                        {value === 4 ? <Input style={{ width: 100, marginLeft: 10 }} /> : null}
                    </Radio>
                </Space>
            </Radio.Group>
        </div>
    );
}


export default Game;