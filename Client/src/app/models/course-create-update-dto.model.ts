export interface CourseCreateUpdateDto {
    courseName: string;
    instructorFirstName: string;
    instructorLastName: string;
    roomName: string;
    startDate: Date;
    endDate: Date;
}
