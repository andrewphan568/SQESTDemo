import React, { useEffect } from 'react';
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
import InputWithMessage from '../../app/common/InputWithMessage';
import * as exampleList from './exampleList'

export default observer(function MoistureContentDetails() {
  const { moistureContentStore } = useStore();
  const { initialLoading, editMode, createMode, selectedMoistureContent, massErrors,
    changeInfo, loadMoistureContent, setEditMode, createMoistureContent, updateMoistureContent,
    clearTestBySegment, clearRemarks } = moistureContentStore;
  const { id } = useParams<{ id: string }>();

  let updateInfo = (newValue: any, key: string, extraKey?: string) => {
    //do nothing
  };
  if (editMode || createMode) {
    updateInfo = changeInfo;
  }

  useEffect(() => {
    if (id) loadMoistureContent(id);
  }, [id, loadMoistureContent]);

  if (initialLoading) return <LoadingComponent content='Loading worksheet...' />

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
              specificationName={selectedMoistureContent?.specification?.name}
              worksheetId={selectedMoistureContent?.worksheetId}
              standardTestMethod={selectedMoistureContent?.standardTestMethod}
              changeInfo={updateInfo}
              editModeOrCreateMode={editMode || createMode} />

            <Header size="small">Preparation</Header>
            <Segment className="section">
              <Grid columns={2}  >
                <Grid.Column>
                  <Form.Field><label>Method:</label></Form.Field>
                  <Form.Field>
                    <Radio label="A" name="SelectMethod" value="A"
                      checked={selectedMoistureContent?.preparation?.method === "A"}
                      onChange={(e) => updateInfo("A", "selectMethod")}
                    />
                  </Form.Field>
                  <Form.Field>
                    <Radio label="B" name="radioGroup" value="B"
                      checked={selectedMoistureContent?.preparation?.method === "B"}
                      onChange={(e) => updateInfo("B", "selectMethod")}
                    />
                  </Form.Field>
                  <Form.Input fluid label='Drying temperature (oC)'
                    onChange={(e) => updateInfo(e.target.value, "dryingtemperature", "PreparationSegment")}
                    defaultValue={selectedMoistureContent?.preparation?.dryingTemperature}
                  />
                  <Form.Select fluid label='Balance:' options={exampleList.balanceEquipments} value={selectedMoistureContent?.preparation?.balance?.code}
                    onChange={(e, v) => updateInfo(v.value, "balanceEquipment", "PreparationSegment")}
                  />
                </Grid.Column>
                <Grid.Column>
                  <Form.Select fluid label='Visual Nominal Particle Size:' options={exampleList.particalSizes}
                    onChange={(e, v) => updateInfo(v.value, "visualNominalParticleSize", "PreparationSegment")}
                    value={selectedMoistureContent?.preparation?.visualNomialPraticalSize} />
                  <Form.Checkbox label='Material Excluded' checked={selectedMoistureContent?.preparation?.materialExcluded ? true : false}
                    onChange={(e, v) => updateInfo(v, "toggleMaterialExcluded", "PreparationSegment")}
                  />
                  <Form.Input fluid disabled={selectedMoistureContent?.preparation?.materialExcluded ? false : true}
                    value={selectedMoistureContent?.preparation?.materialExcluded}
                    onChange={(e, v) => updateInfo(v, "materialExcluded", "PreparationSegment")} />
                  <Form.Select fluid label='Oven:' options={exampleList.ovenEquipments}
                    value={selectedMoistureContent?.preparation?.oven?.code}
                    onChange={(e, v) => updateInfo(v.value, "ovenEquipment", "PreparationSegment")} />
                </Grid.Column>
              </Grid>
            </Segment>

            <Header size="small">Measurements</Header>
            <Segment className="section">
              <Grid columns={2}  >
                <Grid.Column>
                  <Form.Input fluid label='Tare ID:' defaultValue={selectedMoistureContent?.tareId}
                    onChange={(e, v) => updateInfo(v, "tareId", "MeasurementsSegment")} />
                  <InputWithMessage label='Tare and Material Wet Mass(g):' mainKey="tareAndMaterialWetMass" extraKey="MeasurementsSegment"
                    value={selectedMoistureContent?.tareAndMaterialWetMass} changeInfo={updateInfo} warningMessageMC={massErrors.get("tareAndMaterialWetMass")} />
                </Grid.Column>
                <Grid.Column>
                  <InputWithMessage label='Tare Mass (g):' mainKey="tareMass" extraKey="MeasurementsSegment" value={selectedMoistureContent?.tareMass}
                    changeInfo={updateInfo} warningMessageMC={massErrors.get("tareMass")} />
                  <Form.Field>
                    <label>Material wet Mass(g)</label>
                    <p>{selectedMoistureContent?.materialWetMass?.toFixed(2) ?? "N/A"}</p>
                  </Form.Field>
                </Grid.Column>
              </Grid>
            </Segment>

            <TestedBySegment testerName={selectedMoistureContent?.testerName}
              dateTested={selectedMoistureContent.dateTested}
              changeInfo={updateInfo}
              clear={clearTestBySegment}
              editModeOrCreateMode={editMode || createMode} />

            <Header size="small">Dry Mass</Header>
            <Segment className="section">
              <Grid columns={2}  >
                <Grid.Column>
                  <Form.Select fluid label={'Balance:'} options={exampleList.balanceEquipments} value={selectedMoistureContent?.preparation?.balance?.code}
                    onChange={(e, v) => updateInfo(v.value, "dryMassBalance", "DryMassSegment")} />
                  <InputWithMessage label='Tare and Material Dry Mass(g):' mainKey="tareAndMaterialDryMass" extraKey="DryMassSegment"
                    value={selectedMoistureContent?.tareAndMaterialDryMass} changeInfo={updateInfo} warningMessageMC={massErrors.get("tareAndMaterialDryMass")} />
                </Grid.Column>
                <Grid.Column>
                  <Form.Field>
                    <label>Material Dry Mass(g)</label>
                    <p>{selectedMoistureContent?.materialDryMass?.toFixed(2) ?? "N/A"}</p>
                  </Form.Field>
                </Grid.Column>
              </Grid>
            </Segment>

            <ResultsSegment waterContentPercentage={selectedMoistureContent?.waterContentPercentage}
              insufficientSampleMass={selectedMoistureContent?.selectInsufficientSampleMass}
              dryingTemperature={selectedMoistureContent?.selectDryingTemperature}
              materialExcluded={selectedMoistureContent?.selectMaterialExcluded}
              changeInfo={updateInfo}
            />

            <RemarksSegment checkedBy={selectedMoistureContent?.checkerName}
              dateChecked={selectedMoistureContent?.dateChecked}
              content={selectedMoistureContent.remarks}
              changeInfo={updateInfo}
              editModeOrCreateMode={editMode || createMode}
              clear={clearRemarks} />
            {!createMode && !editMode &&
              <Button primary floated='right' onClick={() => setEditMode(true)}> Edit</Button>
            }
            {createMode &&
              <Button primary floated='right' onClick={() => createMoistureContent(selectedMoistureContent)}>Submit </Button>
            }
            {editMode &&
              <Button primary floated='right' onClick={() => updateMoistureContent(selectedMoistureContent)}>Update</Button>
            }
          </Form>
        </>
      }
    </>
  );
})


