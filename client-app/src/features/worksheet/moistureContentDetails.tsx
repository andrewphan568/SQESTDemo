import React, { useEffect, useState } from 'react';
import './worksheetStyles.css';
import { useStore } from '../../app/stores/store';
import { useParams } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import LoadingComponent from '../../app/layout/LoadingComponent';

import {
  Form, Radio, Header, Grid, Segment, Button
} from "semantic-ui-react";

import TestSubjectSegment from './components/TestSubjectSegment';
import TestedBySegment from './components/TestedBySegment';
import RemarksSegment from './components/RemarksSegment';
import ResultsSegment from './components/ResultsSegment';
import * as exmapleList from './exampleList'

export default observer(function MoistureContentDetails() {
  const { moistureContentStore } = useStore();
  const { loadMoistureContent, loading, selectedMoistureContent, changeInfo } = moistureContentStore;
  const { id } = useParams<{ id: string }>();

  useEffect(() => {
    if (id) loadMoistureContent(id);
  }, [id, loadMoistureContent]);

  if (loading) return <LoadingComponent content='Loading worksheet...' />

  return (
    <>
      {selectedMoistureContent &&
        <>
          <Form className="worksheet">

            <TestSubjectSegment projectCode={selectedMoistureContent?.project?.code}
              projectName={selectedMoistureContent?.project?.name}
              sampledBy={selectedMoistureContent?.sample?.sampledBy}
              sampledDate={selectedMoistureContent?.sample?.sampledDate}
              sourceMaterialDesciption={selectedMoistureContent?.sourceMaterial?.materialDesciption}
              sourceMaterialName={selectedMoistureContent?.sourceMaterial?.sourceName}
              specificationName={selectedMoistureContent?.specification?.name} />

            <Header size="small">Preparation</Header>
            <Segment className="section">
              <Grid columns={2}  >
                <Grid.Column>
                  <Form.Field><label>Method:</label></Form.Field>
                  <Form.Field>
                    <Radio
                      label="A"
                      name="SelectMethod"
                      value="A"
                      checked={selectedMoistureContent?.preparation?.method === "A"}
                      onChange={(e) => changeInfo("A", "selectMethod")}
                    />
                  </Form.Field>
                  <Form.Field>
                    <Radio
                      label="B"
                      name="radioGroup"
                      value="B"
                      checked={selectedMoistureContent?.preparation?.method === "B"}
                      onChange={(e) => changeInfo("B", "selectMethod")}
                    />
                  </Form.Field>
                  <Form.Input fluid label='Drying temperature (oC)' defaultValue={selectedMoistureContent?.preparation?.dryingTemperature} />
                  <Button primary>Change</Button>
                  <Form.Select fluid label='Balance:' options={exmapleList.balanceEquipments} />
                </Grid.Column>
                <Grid.Column>
                  <Form.Select fluid label='Visual Nominal Particle Size:' options={exmapleList.particalSizes} />
                  <Form.Checkbox label='Material Excluded' checked={selectedMoistureContent?.preparation?.materialExcluded ? true : false} />
                  <Form.Input fluid disabled={selectedMoistureContent?.preparation?.materialExcluded ? false : true} />
                  <Form.Select fluid label='Oven:' options={exmapleList.ovenEquipments} />
                </Grid.Column>
              </Grid>
            </Segment>

            <Header size="small">Measurements</Header>
            <Segment className="section">
              <Grid columns={2}  >
                <Grid.Column>
                  <Form.Input fluid label='Tare ID:' defaultValue={selectedMoistureContent?.tareId} />
                  <Form.Input fluid label='Tare and Material Wet Mass(g):'
                    defaultValue={selectedMoistureContent?.tareAndMaterialWetMass}
                    onChange={(e) => changeInfo(e.target.value, "tareAndMaterialWetMass")} />
                </Grid.Column>
                <Grid.Column>
                  <Form.Input fluid label='Tare Mass (g):' defaultValue={selectedMoistureContent?.tareMass}
                    onChange={(e) => changeInfo(e.target.value, "tareMass")} />
                  <Form.Field>
                    <label>Material wet Mass(g)</label>
                    <p>{selectedMoistureContent?.tareAndMaterialWetMass}</p>
                  </Form.Field>
                </Grid.Column>
              </Grid>
            </Segment>

            <TestedBySegment testerName={selectedMoistureContent?.testerName} dateTested={selectedMoistureContent.dateTested} />

            <Header size="small">Dry Mass</Header>
            <Segment className="section">
              <Grid columns={2}  >
                <Grid.Column>
                  <Form.Select fluid label={'Balance:'} options={exmapleList.balanceEquipments} />
                  <Form.Input fluid label={'Tare and Material Dry Mass(g):'} defaultValue={selectedMoistureContent?.tareAndMaterialDryMass}
                    onChange={(e) => changeInfo(e.target.value, "tareAndMaterialDryMass")} />
                </Grid.Column>
                <Grid.Column>
                  <Form.Field>
                    <label>Material Dry Mass(g)</label>
                    <p>{selectedMoistureContent?.materialDryMass}</p>
                  </Form.Field>
                </Grid.Column>
              </Grid>
            </Segment>

            <ResultsSegment waterContentPercentage={selectedMoistureContent?.waterContentPercentage}
              insufficientSampleMass={selectedMoistureContent?.selectInsufficientSampleMass}
              dryingTemperature={selectedMoistureContent?.selectDryingTemperature}
              materialExcluded={selectedMoistureContent?.selectMaterialExcluded}
              changeInfo={changeInfo} />

            <RemarksSegment checkedBy={selectedMoistureContent?.checkerName}
              dateChecked={selectedMoistureContent?.dateChecked}
              content={selectedMoistureContent.remarks}
              changeInfo={changeInfo} />
            <Button primary >Update</Button>
          </Form>
        </>
      }
    </>
  );
})


