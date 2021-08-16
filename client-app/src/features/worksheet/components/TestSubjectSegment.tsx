import React from "react";
import {
    Header,
    Form,
    Divider,
    Icon,
    Button,
    Grid,
    Segment,
    Input,
} from "semantic-ui-react";
import moment from 'moment';
import { StandardTestMethod } from "../../../app/models/apiTypes";
import { observer } from 'mobx-react-lite';

interface Props {
    worksheetId?: string;
    standardTestMethod?: StandardTestMethod;
    projectCode?: string;
    projectName?: string;
    sampledDate?: Date;
    sampledBy?: string;
    sourceMaterialName?: string;
    sourceMaterialDesciption?: string;
    specificationName?: string;
    editModeOrCreateMode?: boolean;
    changeInfo: (newValue: any, key: string, extraKey?: string) => void;
}

export default observer(function TestSubjectSegment({
    projectCode,
    projectName,
    sampledDate,
    sampledBy,
    sourceMaterialName,
    sourceMaterialDesciption,
    specificationName,
    worksheetId,
    standardTestMethod,
    editModeOrCreateMode,
    changeInfo
}: Props) {
    return (
        <>
            {!editModeOrCreateMode && (
                <Segment className="section">
                    <Grid columns={3}>
                        <Grid.Column>
                            <Header as="h4" floated="left">
                                {worksheetId ?? ""}
                            </Header>
                        </Grid.Column>
                        <Grid.Column>
                            <Header as="h4"> {standardTestMethod?.code ?? ""} </Header>
                        </Grid.Column>
                        <Grid.Column>
                            <Button icon labelPosition="right" floated="right">
                                Changes Saved
                                <Icon name="undo" />
                            </Button>
                        </Grid.Column>
                    </Grid>
                    <Divider />

                    <Header as="h2" style={{ textAlign: "center" }}>
                        {standardTestMethod?.name ?? ""}
                    </Header>

                    <Grid columns={2}>
                        <Grid.Column>
                            <Form.Field>
                                <label>Project</label>
                                {projectCode && projectName && (
                                    <p>{projectCode + " - " + projectName}</p>
                                )}
                            </Form.Field>
                            <Form.Field>
                                <label>Sampled</label>
                                {sampledDate && sampledBy && (
                                    <p>{moment(sampledDate).format('DD-MM-yyyy') + " by " + sampledBy}</p>
                                )}
                            </Form.Field>
                        </Grid.Column>
                        <Grid.Column>
                            <Form.Field>
                                <label>Source and Material</label>
                                {sourceMaterialName && sourceMaterialDesciption && (
                                    <p>{sourceMaterialName + " - " + sourceMaterialDesciption}</p>
                                )}
                            </Form.Field>
                            <Form.Field>
                                <label>Specification</label>
                                {specificationName && <p>{specificationName}</p>}
                            </Form.Field>
                        </Grid.Column>
                    </Grid>
                </Segment>
            )}
            {editModeOrCreateMode && (
                <Segment className="section">
                    <Grid columns={3}>
                        <Grid.Column>
                            <Form.Input fluid label="Worksheet Id" value={worksheetId ?? ""}
                                onChange={(e) => changeInfo(e.target.value, "worksheetId", "TestSubjectSegment")}
                            />
                        </Grid.Column>
                        <Grid.Column>
                            <Form.Input fluid label="Standard Test Method Code" value={standardTestMethod?.code ?? ""}
                                onChange={(e) => changeInfo(e.target.value, "standardTestMethod.code", "TestSubjectSegment")}
                            />
                        </Grid.Column>
                    </Grid>
                    <Divider />
                    <Form.Field>
                        <h2 style={{ textAlign: "center" }}>Standard Test Method Name</h2>
                        <Input value={standardTestMethod?.name ?? ""}
                            onChange={(e) => changeInfo(e.target.value, "standardTestMethod.name", "TestSubjectSegment")} />
                    </Form.Field>
                    <Grid columns={2}>
                        <Grid.Column>
                            <Form.Group widths='equal'>
                                <Form.Input fluid label="Project Code" value={projectCode ?? ""}
                                    onChange={(e) => changeInfo(e.target.value, "projectCode", "TestSubjectSegment")}
                                />
                                <Form.Input fluid label="Project Name" value={projectName ?? ""}
                                    onChange={(e) => changeInfo(e.target.value, "projectName", "TestSubjectSegment")}
                                />
                            </Form.Group>

                            <Form.Group widths='equal'>
                                <Form.Input type='date' fluid label="Sampled Date" value={sampledDate ? moment(sampledDate).format('yyyy-MM-DD') : undefined}
                                    onChange={(e) => changeInfo(e.target.value, "sampledDate", "TestSubjectSegment")}
                                />
                                <Form.Input fluid label="Sampled By" value={sampledBy ?? ""}
                                    onChange={(e) => changeInfo(e.target.value, "sampledBy", "TestSubjectSegment")}
                                />
                            </Form.Group >
                        </Grid.Column>
                        <Grid.Column>
                            <Form.Group widths='equal'>
                                <Form.Input fluid label="Source Name" value={sourceMaterialName ?? ""}
                                    onChange={(e) => changeInfo(e.target.value, "sourceMaterialName", "TestSubjectSegment")}
                                />
                                <Form.Input fluid label="Material Description" value={sourceMaterialDesciption ?? ""}
                                    onChange={(e) => changeInfo(e.target.value, "sourceMaterialDesciption", "TestSubjectSegment")}
                                />
                            </Form.Group>
                            <Form.Input fluid label="Specification" value={specificationName ?? ""}
                                onChange={(e) => changeInfo(e.target.value, "specificationName", "TestSubjectSegment")}
                            />
                        </Grid.Column>
                    </Grid>
                </Segment>
            )}
        </>
    );
})
