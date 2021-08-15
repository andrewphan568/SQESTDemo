import React from 'react';
import {
    Form, TextArea, Header, Grid, Segment,
} from "semantic-ui-react";

interface Props {
    checkedBy?: string
    dateChecked?: Date,
    content?: string,
    changeInfo: (newValue: any, key: string, extraKey?: string) => void
}

export default function RemarksSegment({ checkedBy, dateChecked, content, changeInfo }: Props) {
    return (
        <>
            <Header size="small">Remarks</Header>
            <Segment className="section">
                <TextArea style={{ minHeight: 100 }} defaultValue={content} onChange={(e) => changeInfo(e.target.value, "remarksContent")} />
                <Header size="small">Review</Header>
                <Grid className="section" columns={2}  >
                    <Grid.Column>
                        <Form.Input fluid label='Checked By' value={checkedBy} onChange={(e) => changeInfo(e.target.value, "checkedBy")} />
                        <Form.Button primary content='Clear' />
                    </Grid.Column>
                    <Grid.Column>
                        <Form.Input fluid label='Date Checked' value={dateChecked} onChange={(e) => changeInfo(e.target.value, "dateChecked")} />
                    </Grid.Column>
                </Grid>
            </Segment>
        </>
    )
}