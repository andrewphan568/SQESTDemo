import React from 'react';
import {
    Form, Button, TextArea, Header, Grid, Segment,
} from "semantic-ui-react";
import { observer } from 'mobx-react-lite';
import moment from 'moment';
interface Props {
    checkedBy?: string
    dateChecked?: Date,
    content?: string,
    editModeOrCreateMode?: boolean;
    changeInfo: (newValue: any, key: string, extraKey?: string) => void;
    clear: () => void;
}


export default observer(function RemarksSegment({ checkedBy, dateChecked, content, editModeOrCreateMode, changeInfo, clear }: Props) {
    return (
        <>
            <Header size="small">Remarks</Header>
            <Segment className="section">
                <TextArea style={{ minHeight: 100 }} defaultValue={content}
                    onChange={(e) => changeInfo(e.target.value, "remarksContent", "RemarksSegment")} />
                <Header size="small">Review</Header>
                <Grid className="section" columns={2}  >
                    <Grid.Column>
                        <Form.Input fluid label='Checked By' value={checkedBy}
                            onChange={(e) => changeInfo(e.target.value, "checkedBy", "RemarksSegment")} />
                        <Button primary disabled={!editModeOrCreateMode} onClick={() => clear()} >Clear </Button>
                    </Grid.Column>
                    <Grid.Column>
                        <Form.Input fluid input='date' label='Date Checked' value={dateChecked ? moment(dateChecked).format('yyyy-MM-DD') : undefined}
                            onChange={(e) => changeInfo(e.target.value, "dateChecked", "RemarksSegment")} />
                    </Grid.Column>
                </Grid>
            </Segment>
        </>
    )
})