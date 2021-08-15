import { makeAutoObservable, runInAction } from "mobx";
import agent from "../agent";
import { history } from '../../';
import { MoistureContent, Preparation } from "../models/apiTypes";

export default class MoistureContentStore {
    loading = false;
    refresh = false;
    moistureContents: MoistureContent[] = [];
    selectedMoistureContent: MoistureContent = new MoistureContent();

    constructor() {
        makeAutoObservable(this)
    }

    loadMoistureContents = async () => {
        this.loading = true;
        try {
            const moistureContents = await agent.MoistureContents.list();
            runInAction(() => {
                this.moistureContents = moistureContents;
            })
            this.setloading(false);
        } catch (error) {
            this.setloading(false);
        }
    }

    loadMoistureContent = async (id: string) => {
        let moistureContent = this.getMoistureContent(id);
        if (moistureContent) {
            this.selectedMoistureContent = moistureContent;
            return moistureContent;
        } else {
            this.loading = true;
            try {
                moistureContent = await agent.MoistureContents.details(id);
                if (moistureContent) {
                    runInAction(() => {
                        this.selectedMoistureContent = moistureContent!;
                    })
                }
                this.setloading(false);
                return moistureContent;
            } catch (error) {
                console.log(error);
                this.setloading(false);
            }
        }
    }

    private getMoistureContent = (id: string) => {
        return this.moistureContents.find(m => m.id === id);
    }

    setloading = (state: boolean) => {
        this.loading = state;
    }
    setRefresh = () => {
        this.refresh = !this.refresh;
    }

    changeInfo = async (newValue: any, key: string, extraKey?: string) => {
        console.log(newValue);
        if (key === "checkedBy") {
            this.selectedMoistureContent.checkerName = newValue;
        }
        else if (key === "dateChecked") {
            this.selectedMoistureContent.dateChecked = newValue;
        }
        else if (key === "remarkContent") {
            this.selectedMoistureContent.remarks = newValue;
        }
        else if (key === "selectInsufficientSampleMass") {
            this.selectedMoistureContent.selectInsufficientSampleMass = !this.selectedMoistureContent.selectInsufficientSampleMass;
        }
        else if (key === "selectMaterialExcluded") {
            this.selectedMoistureContent.selectMaterialExcluded = !this.selectedMoistureContent.selectMaterialExcluded;
        }
        else if (key === "selectDryingTemperature") {
            this.selectedMoistureContent.selectDryingTemperature = !this.selectedMoistureContent.selectDryingTemperature;
        }
        else if (key === "tareAndMaterialDryMass") {
            this.selectedMoistureContent.tareAndMaterialDryMass = newValue;
        }
        else if (key === "tareMass") {
            this.selectedMoistureContent.tareMass = newValue;
        }
        else if (key === "tareAndMaterialWetMass") {
            this.selectedMoistureContent.tareAndMaterialWetMass = newValue;
        }
        else if (key === "selectMethod") {
            if (!this.selectedMoistureContent.preparation) {
                this.selectedMoistureContent.preparation = new Preparation();
            }
            this.selectedMoistureContent.preparation.method = newValue;
        }
        else if (key === "tareAndMaterialDryMass") {
            this.selectedMoistureContent.tareAndMaterialDryMass = newValue;
        }

    }
}


