export class Param {
  /**
   * @param {number|null} active
   * @param {string|null} direction
   * @param {ThisType} _this
   */
  constructor (
    active = null,
    direction = null,
    _this = null,
  ) {
    this._this = _this
    this.active = active
    this.direction = direction

    this.Valid()
  }

  /** @type {number} */
  active

  /** @type {'child'|'parent'|null} */
  direction

  _this = null;

  /**
   * @return {Boolean}
   */
  Valid () {
    if (this.direction !== 'child' && this.direction !== 'parent' && this.direction !== null) throw new Error(`Param.direction: ${this.direction}`)
  }
}
