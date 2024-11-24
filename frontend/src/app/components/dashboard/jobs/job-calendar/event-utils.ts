import { EventInput } from '@fullcalendar/core';

let eventGuid = 0;
const TODAY_STR = new Date().toISOString().replace(/T.*$/, ''); // YYYY-MM-DD of today
let currentDate = new Date();
let nextDays = currentDate.setDate(currentDate.getDate() + 2);
export const INITIAL_EVENTS: EventInput[] = [
  {
    id: createEventId(),
    title: 'All-day event',
    start: TODAY_STR,
    classNames: ['highlight-event']
  },
  {
    id: createEventId(),
    title: 'Timed event',
    start: TODAY_STR + 'T00:00:00',
    end: nextDays,
    classNames: ['highlight-event']
  },
  {
    id: createEventId(),
    title: 'Timed event',
    start: TODAY_STR + 'T12:00:00',
    end: TODAY_STR + 'T15:00:00',
    classNames: ['highlight-event']
  }
];

export function createEventId() {
  return String(eventGuid++);
}
