# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.3](https://github.com/dbrattli/Feliz.ViewEngine/compare/v1.0.2...v1.0.3) (2025-12-02)


### Bug Fixes

* add conventional commit prefix to dependabot config ([304800e](https://github.com/dbrattli/Feliz.ViewEngine/commit/304800ecb2ab9c78f6062472f4cb2f76316bfaff))
* add conventional commit prefix to dependabot config ([98c577a](https://github.com/dbrattli/Feliz.ViewEngine/commit/98c577a6408afb8b799d7d5bd586adcf1101b66b))

## [1.0.2](https://github.com/dbrattli/Feliz.ViewEngine/compare/v1.0.1...v1.0.2) (2025-12-02)


### Bug Fixes

* border style type mismatch in composite border functions ([6482068](https://github.com/dbrattli/Feliz.ViewEngine/commit/6482068416d96cda448440c95ccfc65f7094e762))
* border style type mismatch in composite border functions ([d1e5845](https://github.com/dbrattli/Feliz.ViewEngine/commit/d1e584561c8bf7ac91407407059579644e6ae992))

## [1.0.1](https://github.com/dbrattli/Feliz.ViewEngine/compare/v1.0.0...v1.0.1) (2025-12-02)


### Performance Improvements

* optimize HTML rendering for 35-55% faster performance ([dae37f6](https://github.com/dbrattli/Feliz.ViewEngine/commit/dae37f653090aa8145aea673b5aeb779667e11dd))
* optimize HTML rendering for 35-55% faster performance ([eb460a7](https://github.com/dbrattli/Feliz.ViewEngine/commit/eb460a7e02810cad1c83b2a77cb8df8f50087dde))

## [1.0.0](https://github.com/dbrattli/Feliz.ViewEngine/compare/v0.27.0...v1.0.0) (unreleased)

### Features

* First stable release of Feliz.ViewEngine
* Minimal event handler support in ReactElement DOM (not rendered, but available for inspection)

### Bug Fixes

* Fix Bulma.input properties being ignored (fixes #16, #22)
* Relax FSharp.Core dependency constraint to allow modern versions (fixes #27)
* Add Html.table overload for children elements (fixes #19)

### Build

* Add release-please for automated releases
* Add conventional commit enforcement for PRs
* Add dependabot for GitHub Actions updates
