export interface Project {
    createdAtUtc: Date;
    updatedAtUtc: Date;
    id: string;
    name: string;
    code: string;
}

export interface SourceMaterial {
    createdAtUtc: Date;
    updatedAtUtc: Date;
    id: string;
    sourceName: string;
    materialDesciption: string;
}

export interface Specification {
    createdAtUtc: Date;
    updatedAtUtc: Date;
    id: string;
    name: string;
    code: string;
}

export interface Sample {
    createdAtUtc: Date;
    updatedAtUtc: Date;
    id: string;
    name: string;
    sampledBy: string;
    sampledDate: Date;
    projectId: string;
}

export interface Preparation {
    createdAtUtc: Date;
    updatedAtUtc: Date;
    id: string;
    method: string;
    dryingTemperature: number;
    balanceId: string;
    visualNomialPraticalSize: number;
    materialExcluded: string;
}

export interface MoistureContent {
    id: string;
    project: Project;
    sourceMaterial: SourceMaterial;
    specification: Specification;
    sample: Sample;
    preparation: Preparation;
    tareId: string;
    tareMass: number;
    tareAndMaterialWetMass: number;
    tareAndMaterialDryMass: number;
    materialDryMass: number;
    waterContentPercentage: number;
    selectInsufficientSampleMass: boolean;
    selectDryingTemperature: boolean;
    selectMaterialExcluded: boolean;
    testerName: string;
    dateTested: Date;
    remarks: string;
    checkerName: string;
    dateChecked: Date;
}

export interface Result {
    isSuccess: boolean;
    value: undefined;
    error: string;
}


