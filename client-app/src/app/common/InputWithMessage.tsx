import React from 'react';
import { Form, Message } from 'semantic-ui-react';
import { WarningMessageMC } from '../models/apiTypes';
import { observer } from 'mobx-react-lite';

interface Props {
    label?: string;
    key: string;
    extraKey?: string;
    value: any;
    warningMessageMC?: WarningMessageMC
    changeInfo: (newValue: any, key: string, extraKey?: string) => void
}

// for Moisture Content Details Form
export default observer(function InputWithMessage(props: Props) {
    const { key, value, label, warningMessageMC, changeInfo } = props;
    const isError = warningMessageMC?.isError;
    const isWaring = warningMessageMC?.isWarning;
    const message = warningMessageMC?.message;

    return (
        <Form.Field error={isError} warning={isWaring}>
            <label>{label}</label>
            <input value={value} />
            <Message
                error={isError} warning={isWaring}
                content={message}
            />
        </Form.Field >
    )
})