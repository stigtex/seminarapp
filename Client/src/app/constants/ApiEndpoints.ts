const SERVER_BASE_URL_DEVELOPMENT = 'http://localhost:5111';

const BASE_ENDPOINTS = {
    CREATE_SEMINAR: 'seminars',
    GET_ALL_SEMINARS: 'seminars',
    GET_SEMINAR_BY_ID: 'seminars',
    UPDATE_SEMINAR: 'seminars',
    DELETE_SEMINAR: 'seminars/delete',
    CREATE_PARTICIPANT: 'participants',
    GET_ALL_PARTICIPANTS: 'participants',
    GET_PARTICIPANT_BY_ID: 'participants',
    UPDATE_PARTICIPANT: 'participants',
    DELETE_PARTICIPANT: 'participants/delete',
    ADD_COURSE_PARTICIPANT: 'participants/course',
    GET_COURSE_PARTICIPANTS: 'participants/course',
    CREATE_COURSE: 'courses',
    GET_ALL_COURSES: 'courses',
    GET_COURSE_BY_ID: 'courses',
    UPDATE_COURSE: 'courses',
    DELETE_COURSE: 'courses/delete',
    ADD_SEMINAR_COURSE: 'courses/seminar',
    GET_SEMINAR_COURSES: 'courses/seminar',
};

const DEVELOPMENT_ENDPOINTS = {
    CREATE_SEMINAR: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.CREATE_SEMINAR}`,
    GET_ALL_SEMINARS: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_ALL_SEMINARS}`,
    GET_SEMINAR_BY_ID: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_SEMINAR_BY_ID}`,
    UPDATE_SEMINAR: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.UPDATE_SEMINAR}`,
    DELETE_SEMINAR: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.DELETE_SEMINAR}`,
    CREATE_PARTICIPANT: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.CREATE_PARTICIPANT}`,
    GET_ALL_PARTICIPANTS: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_ALL_PARTICIPANTS}`,
    GET_PARTICIPANT_BY_ID: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_PARTICIPANT_BY_ID}`,
    UPDATE_PARTICIPANT: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.UPDATE_PARTICIPANT}`,
    DELETE_PARTICIPANT: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.DELETE_PARTICIPANT}`,
    ADD_COURSE_PARTICIPANT: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.ADD_COURSE_PARTICIPANT}`,
    GET_COURSE_PARTICIPANTS: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_COURSE_PARTICIPANTS}`,
    CREATE_COURSE: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.CREATE_COURSE}`,
    GET_ALL_COURSES: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_ALL_COURSES}`,
    GET_COURSE_BY_ID: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_COURSE_BY_ID}`,
    UPDATE_COURSE: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.UPDATE_COURSE}`,
    DELETE_COURSE: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.DELETE_COURSE}`,
    ADD_SEMINAR_COURSE: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.ADD_SEMINAR_COURSE}`,
    GET_SEMINAR_COURSES: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_SEMINAR_COURSES}`,
};

const ENDPOINTS_TO_EXPORT = DEVELOPMENT_ENDPOINTS;

export default ENDPOINTS_TO_EXPORT;