import React from 'react';
import { Form, Label } from 'semantic-ui-react';
import { WarningMessageMC } from '../models/apiTypes';
import { observer } from 'mobx-react-lite';

interface Props {
    label?: string;
    mainKey: string;
    extraKey?: string;
    value: any;
    warningMessageMC?: WarningMessageMC
    changeInfo: (newValue: any, key: string, extraKey?: string) => void
}

// for Moisture Content Details Form
export default observer(function InputWithMessage(props: Props) {
    const { mainKey, value, label, warningMessageMC, extraKey, changeInfo } = props;
    const isError = warningMessageMC?.isError;
    const isWarning = warningMessageMC?.isWarning;
    const message = warningMessageMC?.message;

    return (
        <>
            <Form.Field error={isError} warning={isWarning}>
                <label>{label}</label>
                <input type='number' value={value} onChange={(e) => changeInfo(e.target.value, mainKey, extraKey)} />
            </Form.Field >
            {(isError || isWarning) &&

                <Label basic color={isError ? 'red' : 'yellow'}>{message}</Label>
            }
        </>
    )
}
)
