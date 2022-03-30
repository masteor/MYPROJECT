/* eslint-disable quotes */
import { ОБЪЕКТ_ПРОФИЛЯ, ТипОбъектовСервисов, ТипСервисов } from '@/store/param-types'

test('new ОБЪЕКТ_ПРОФИЛЯ()', () => {
  expect(() => new ОБЪЕКТ_ПРОФИЛЯ())
    .toThrowError(Error)
})

test(`new ОБЪЕКТ_ПРОФИЛЯ(0, null, null, '', null, null)`, () => {
  expect(() =>
    new ОБЪЕКТ_ПРОФИЛЯ(
      0, null, null, '',
      null, null))
    .toThrowError(Error)
})

test(`new ОБЪЕКТ_ПРОФИЛЯ(1, null, null, '', null, null)`, () => {
  expect(() =>
    new ОБЪЕКТ_ПРОФИЛЯ(
      1, null, null, '',
      null, null))
    .toThrowError(Error)
})

test(`new ОБЪЕКТ_ПРОФИЛЯ(1, null, null, 'qw', null, null)`, () => {
  expect(() =>
    new ОБЪЕКТ_ПРОФИЛЯ(
      1, null, null, 'qw',
      null, null))
    .toThrowError(Error)
})

test(`Валидный конструктор new ОБЪЕКТ_ПРОФИЛЯ(1, null, null, 'qw', new ТипОбъектовСервисов(1, 'w'), null) не бросает исключение`, () => {
  expect(() =>
    new ОБЪЕКТ_ПРОФИЛЯ(
      1, null, null, 'qw',
      new ТипОбъектовСервисов(
        1,
        'й',
        1,
        1,
        new ТипСервисов(1, 'q'),
        'ф',
        'ы'), [1]))
    .not.toThrowError(Error)
})
