class Class {
  constructor (id) {
    this.id = id
  }

  id

  ThrowIfNotValid () {
    if (this?.id < 1) throw new Error('this.id < 1')
  }
}

test('test', () =>
  expect(() => {
    // eslint-disable-next-line no-new
    const class1 = new Class(undefined)
    class1.ThrowIfNotValid()
  }).not.toThrow(Error),
)
